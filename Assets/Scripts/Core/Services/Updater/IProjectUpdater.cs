using System;
using System.Collections;

namespace Core.Services.Updater
{
    public interface IProjectUpdater
    {
        event Action UpdateCalled;
        event Action FixedUpdateCalled;
        event Action LateUpdateCalled;
        void StartCoroutine(IEnumerator coroutine);
        void StopCoroutine(IEnumerator coroutine); 
    };
}