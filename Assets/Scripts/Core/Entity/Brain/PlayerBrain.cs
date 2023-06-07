using System;
using System.Collections.Generic;
using System.Linq;
using Core.Services.Updater;
using InputReader;
using Player;

namespace Core.Entity.Brain
{
    public class PlayerBrain : IDisposable
    {
        private readonly PlayerEntity _playerEntity;
        private readonly List<IEntityInputSource> _inputSources;
        private readonly IProjectUpdater _projectUpdater;
        
        public PlayerBrain(PlayerEntity playerEntity, List<IEntityInputSource> entityInputSources)
        {
            _playerEntity = playerEntity;
            _inputSources = entityInputSources;
            ProjectUpdater.Instance.UpdateCalled += OnFixedUpdate;
        }
        
        public void Dispose() => ProjectUpdater.Instance.UpdateCalled -= OnFixedUpdate;
        
        private void OnFixedUpdate()
        {
            _playerEntity.MoveHorizontally(GetHorizontalDirection());
            _playerEntity.MoveVertically(GetVerticalDirection());
            
            
            if(IsAttack())
                _playerEntity.StartAttack();

            foreach (var inputSource in _inputSources)
                inputSource.ResetOneTimeActions();
        }

        private float GetHorizontalDirection() =>
            (from t in _inputSources where t.HorizontalDirection != 0 select t.HorizontalDirection).FirstOrDefault();

        private float GetVerticalDirection() => 
            (from t in _inputSources where t.VerticalDirection != 0 select t.VerticalDirection).FirstOrDefault();

       
        private bool IsAttack() => _inputSources.Any(source => source.Attack);

       
    }
}