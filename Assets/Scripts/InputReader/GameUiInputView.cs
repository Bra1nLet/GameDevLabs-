using UnityEngine;
using UnityEngine.UI;

namespace InputReader
{
    public class GameUiInputView : MonoBehaviour, IEntityInputSource
    {
        [SerializeField] private Joystick _joystick;
        [SerializeField] private Button _attackButton;
        [SerializeField] private Button _jumpButton;

        public float HorizontalDirection => _joystick.Horizontal;
        public float VerticalDirection => _joystick.Vertical;
        public bool Jump { get; private set; }
        public bool Attack { get; private set; }

        private void Awake()
        {
            _attackButton.onClick.AddListener(() => Attack = true);
            _jumpButton.onClick.AddListener(() => Jump = true);
        }

        public void ResetOneTimeActions()
        {
            Jump = false;
            Attack = false;
        }
    }
}