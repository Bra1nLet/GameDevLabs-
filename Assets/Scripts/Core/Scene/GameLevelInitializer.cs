using System.Collections.Generic;
using Core.Services.Updater;
using InputReader;
using Player;
using UnityEngine;

namespace Core.Scene
{
    public class GameLevelInitializer : MonoBehaviour
    {
        [SerializeField] private GameUiInputView _gameUiInputView;
        [SerializeField] private PlayerEntity _playerEntity;
        
        private ProjectUpdater _projectUpdater;
        private PlayerSystem _playerSystem;

        private ExternalDevicesInputReader _externalDevicesInputReader;
        
        private void Awake()
        {
            if (ProjectUpdater.Instance == null)
                _projectUpdater = new GameObject().AddComponent<ProjectUpdater>();
            else
                _projectUpdater = ProjectUpdater.Instance as ProjectUpdater;
            
            _externalDevicesInputReader = new ExternalDevicesInputReader();
            _playerSystem = new PlayerSystem(new List<IEntityInputSource>
            {
                _gameUiInputView,
                _externalDevicesInputReader
            }, _playerEntity);
        }
    }
}