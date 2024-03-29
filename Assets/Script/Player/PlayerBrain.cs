﻿using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace Player 
{
    public class PlayerBrain  
    {
        private readonly PlayerEntity _playerEntity;
        private readonly List<IEntityInputSource> _inputSources;
        
        public PlayerBrain(PlayerEntity playerEntity, List<IEntityInputSource> inputSources)
        {
            _playerEntity = playerEntity;
            _inputSources = inputSources;
        }

        public void OnFixedUpdate()
        {
            _playerEntity.HMove(GetHorizontalDirection());
            _playerEntity.VMove(GetVerticalDirection());
            
            if (IsAttack) _playerEntity.Attack();
            foreach (var inputSource in _inputSources)
            {
                inputSource.ResetOneTimeActions();
            }
        }

 

        private float GetHorizontalDirection()
        {
            foreach (var inputSource in _inputSources)
            {
                if (inputSource.HorizontalDirection == 0)
                    continue;
                return inputSource.HorizontalDirection;
            }
            return 0; 
        }
        
        private float GetVerticalDirection()
        {
            foreach (var inputSource in _inputSources)
            {
                if (inputSource.VerticalDirection == 0)
                    continue;
                return inputSource.VerticalDirection;
            }
            return 0;
        }

        private bool IsAttack => _inputSources.Any(source => source.Attack);
    }
} 