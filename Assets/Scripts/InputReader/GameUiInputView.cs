using UnityEngine;
using UnityEngine.UI;
using System;
namespace InputReader
{
    public class GameUiInputView : MonoBehaviour, IEntityInputSource, IWindowsInputSource
    {
        [SerializeField] private Joystick _joystick;
        [SerializeField] private Button _attackButton;
        

        public float HorizontalDirection => _joystick.Horizontal;
        public float VerticalDirection => _joystick.Vertical;
 
        public bool Attack { get; private set; }
        
        public event Action InventoryRequested;
        public event Action SkillsWindowRequested;
        public event Action QuestWindowRequested;
        public event Action SettingsMenuRequested;

        private void Awake()
        {
            _attackButton.onClick.AddListener(() => Attack = true);
        }

        public void ResetOneTimeActions()
        {
            Attack = false;
        }
    }
}