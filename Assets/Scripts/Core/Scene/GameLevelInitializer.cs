using System.Collections.Generic;
using System.Linq;
using Core.Services.Updater;
using InputReader;
using Items;
using Items.Data;
using Items.Rarity;
using Items.Storage;
using Player;
using UI;
using UnityEngine;

namespace Core.Scene
{
    public class GameLevelInitializer : MonoBehaviour
    {
        [SerializeField] private GameUiInputView _gameUiInputView;
        [SerializeField] private PlayerEntity _playerEntity;
        [SerializeField] private ItemRarityDescriptorsStorage _rarityDescriptorsStorage;
        [SerializeField] private LayerMask _whatIsPlayer;
        [SerializeField] private ItemsStorage _itemsStorage;

        private ProjectUpdater _projectUpdater;
        private PlayerSystem _playerSystem;
        private DropGenerator _dropGenerator;
        private ItemsSystem _itemsSystem;
        private UIContext _uiContext;

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

            ItemsFactory itemsFactory = new ItemsFactory(_playerSystem.StatsController);
            List<IItemRarityColor> rarityColors = _rarityDescriptorsStorage.RarityDescriptors.Cast<IItemRarityColor>().ToList();
            _itemsSystem = new ItemsSystem(rarityColors, itemsFactory, _whatIsPlayer, _playerSystem.Inventory);
            List<ItemDescriptor> descriptors = _itemsStorage.ItemScriptables.Select(scriptable => scriptable.ItemDescriptor).ToList();
            _dropGenerator = new DropGenerator(descriptors, _playerEntity, _itemsSystem);

            UIContext.Data data = new UIContext.Data(_playerSystem.Inventory, _rarityDescriptorsStorage.RarityDescriptors);
            _uiContext = new UIContext(new List<IWindowsInputSource>
            {
                _gameUiInputView,
                _externalDevicesInputReader
            }, data);
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
                _uiContext.CloseCurrentScreen();
        }
    }
}