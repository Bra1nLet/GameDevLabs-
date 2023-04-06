using System;
using UnityEngine;
using UnityEngine.UI;
//test
namespace Player
{
    public class GameUIInputView : MonoBehaviour, IEntityInputSource
    {
        [SerializeField] private Joystick _joystick;
        [SerializeField] private Button _attackButton;
        
        public bool Attack { get; private set;}
        public float HorizontalDirection => _joystick.Horizontal;
        public float VerticalDirection => _joystick.Vertical;
        

        private void Awake()
        {
            _attackButton.onClick.AddListener(()=>Attack=true);
        }

        private void OnDestroy()
        {
            _attackButton.onClick.RemoveAllListeners();
        }

        public void ResetOneTimeActions()
        {
            Attack = false;
        }
    }
}