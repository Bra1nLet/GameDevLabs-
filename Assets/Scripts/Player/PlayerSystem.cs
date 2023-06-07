using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entity.Brain;
using Core.Services.Updater;
using InputReader;
using StatsSystem;
using UnityEngine;

namespace Player
{
    public class PlayerSystem : IDisposable
    {
        private const string PlayerFolder = "Player";

        private readonly ProjectUpdater _projectUpdater;
        private readonly PlayerEntity _playerEntity;
        private readonly PlayerBrain _playerBrain;
        private readonly StatsController _statsController;

        private List<IDisposable> _disposables;
        
        public PlayerSystem(List<IEntityInputSource> inputSources, PlayerEntity playerEntity)
        {
            _disposables = new List<IDisposable>();
           
            var statsStorage = Resources.Load<StatsStorage>($"Player/{nameof(StatsStorage)}");
            var stats = statsStorage.Stats.Select(stat => stat.GetCopy()).ToList();
            _statsController = new StatsController(stats);
            _disposables.Add(_statsController);
            
            _playerEntity = playerEntity;
            _playerEntity.Initialize(_statsController);
            
            _playerBrain = new PlayerBrain(_playerEntity, inputSources);
            _disposables.Add(_playerBrain);
        }

        public void Dispose()
        {
            foreach (var disposable in _disposables)
                disposable.Dispose();
        }
    }
}