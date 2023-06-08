using System;
using UnityEngine;

namespace Core.Animation
{
    public abstract class AnimatorController : MonoBehaviour
    {
        private AnimationType _currentAnimationType;
        

        private Action _animationAction;
        private Action _animationEndAction;

        public bool SetAnimationState(AnimationType animationType, bool active,  Action animationAction = null, Action endAnimationAction = null, float speedH = 0, float speedV = 0)
        {
            if (!active)
            {
                return false;
            }

            //if (_currentAnimationType >= animationType)
            //    return false;
            
            
            _animationAction = animationAction;
            _animationEndAction = endAnimationAction;
             
           if (speedV >= 0 && -0.75f < speedH && speedH < 0.75f)
           {
               animationType = AnimationType.Back;
           } else if (speedV <= 0 && -0.75f < speedH && speedH < 0.75f)
           {
               animationType = AnimationType.Front;
           } else if (speedH >= 0 && -0.75f < speedV && speedV < 0.75f)
           {
               animationType = AnimationType.Right;
           } else if (speedH <= 0 && -0.75f < speedV && speedV < 0.75f)
           {
               animationType = AnimationType.Left;
           }
           
            SetAnimation(animationType);
            return true;
        }

        private void SetAnimation(AnimationType animationType)
        {
            _currentAnimationType = animationType;
            PlayAnimation(_currentAnimationType);
        }

        protected abstract void PlayAnimation(AnimationType animationType);

        protected void OnActionRequested()
        {
            _animationAction?.Invoke();
            _animationAction = null;
        } 
        
        protected void OnAnimationEnded()
        {
            _animationEndAction?.Invoke();
            _animationEndAction = null;
            SetAnimation(AnimationType.Front);
        } 
    }
}