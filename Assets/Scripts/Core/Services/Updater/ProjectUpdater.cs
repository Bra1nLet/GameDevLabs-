using System;
using System.Collections;
using UnityEngine;

namespace Core.Services.Updater
{
    public class ProjectUpdater : MonoBehaviour, IProjectPause, IProjectUpdater
    {
        public static IProjectUpdater Instance;
        
        public bool IsPaused { get; set; }
        
        public event Action UpdateCalled;
        public event Action FixedUpdateCalled;
        public event Action LateUpdateCalled;

        void IProjectUpdater.StartCoroutine(IEnumerator coroutine) => StartCoroutine(coroutine);
        void IProjectUpdater.StopCoroutine(IEnumerator coroutine) => StopCoroutine(coroutine);

        public void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        private void Update()
        {
            if (IsPaused)
                return;
            
            UpdateCalled?.Invoke();
        }
        
        private void LateUpdate()
        {
            if (IsPaused)
                return;
            
            LateUpdateCalled?.Invoke();
        }

        private void FixedUpdate()
        {
            if (IsPaused)
                return;
            
            FixedUpdateCalled?.Invoke();
        }
    }
}