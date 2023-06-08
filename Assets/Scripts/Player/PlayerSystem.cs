using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entity.Brain;
using Core.Services.Updater;
using InputReader;
using Items;
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
        public StatsController StatsController { get; }
        public Inventory Inventory { get; }

        private List<IDisposable> _disposables;
        
        public PlayerSystem(List<IEntityInputSource> inputSources, PlayerEntity playerEntity)
        {
            _disposables = new List<IDisposable>();
           
            var statsStorage = Resources.Load<StatsStorage>($"Player/{nameof(StatsStorage)}");
            var stats = statsStorage.Stats.Select(stat => stat.GetCopy()).ToList();
            StatsController = new StatsController(stats);
            _disposables.Add(StatsController);
            
            _playerEntity = playerEntity;
            _playerEntity.Initialize(StatsController);
            
            _playerBrain = new PlayerBrain(_playerEntity, inputSources);
            _disposables.Add(_playerBrain);

            Inventory = new Inventory(null, null, _playerEntity.transform, new EquipmentConditionChecker());
        }

        public void Dispose()
        {
            foreach (var disposable in _disposables)
                disposable.Dispose();
        }
    }
}