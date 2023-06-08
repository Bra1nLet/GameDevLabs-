using System;
using Core.Services.Updater;
using UnityEngine;

namespace InputReader
{
    public class ExternalDevicesInputReader : IEntityInputSource, IDisposable
    {
        public float HorizontalDirection => Input.GetAxisRaw("Horizontal");
        public float VerticalDirection => Input.GetAxisRaw("Vertical");
      
        public bool Attack { get; private set; }

        public event Action InventoryRequested;
        public event Action CharacterWindowRequested;
        public event Action SettingsMenuRequested;

        public ExternalDevicesInputReader()
        {
            ProjectUpdater.Instance.UpdateCalled += OnUpdate;
        }
        
        public void ResetOneTimeActions()
        {
       
            Attack = false;
        }

        public void Dispose() => ProjectUpdater.Instance.UpdateCalled -= OnUpdate;
        
        private void OnUpdate()
        {
            if (Input.GetButtonDown("Fire1"))
                Attack = false;
        }
    }
}