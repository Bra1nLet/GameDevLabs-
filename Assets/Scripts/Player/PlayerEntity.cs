using Cinemachine;
using Core.Animation;
using Core.Movement.Controllers;
using StatsSystem;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerEntity : MonoBehaviour
    {




        private Rigidbody2D _rigidbody;
        private AnimatorController _animatorController;
        private StatsController _statsController;
        private EntityDirectionalMover _directionalMover;
 

        private bool _inAction;

        public void Initialize(StatsController statsController)
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animatorController = GetComponentInChildren<AnimatorController>();
            _statsController = statsController;
            _directionalMover = new EntityDirectionalMover(_rigidbody, _statsController);
          
        }

        private void Update()
        {
            UpdateAnimation();
        }

        public void MoveHorizontally(float horizontalDirection) =>
            _directionalMover.MoveHorizontally(horizontalDirection);

        public void MoveVertically(float verticalDirection) =>
            _directionalMover.MoveVertically(verticalDirection);
        

       

        
        private void UpdateAnimation()
        {
            _animatorController.SetAnimationState(AnimationType.Death, _directionalMover.IsMoving, speedH: _directionalMover.GetHSpeed(), speedV: _directionalMover.GetVSpeed());
            _animatorController.SetAnimationState(AnimationType.Hit, _directionalMover.IsMoving, speedH: _directionalMover.GetHSpeed(), speedV: _directionalMover.GetVSpeed());
      
        }

        public void StartAttack()
        {
            if (_inAction)
                return;
            
            _inAction = _animatorController.SetAnimationState(AnimationType.Attack, true, Attack, EndAction);
        }
        
        public void StartCast()
        {
            if (_inAction)
                return;
            
            _inAction = _animatorController.SetAnimationState(AnimationType.Attack, true, Cast, EndAction);
        }
        
        public void StartUseSupply()
        {
            if (_inAction)
                return;
            
            _inAction = _animatorController.SetAnimationState(AnimationType.Attack, true, UseSupply, EndAction);
        }
        
        private void Attack()
        {
            Debug.Log("Attack");
        }

        private void Cast()
        {
            Debug.LogError("Cast");
        }

        private void UseSupply()
        {
            Debug.LogError("UseSupply");
        }

        private void EndAction()
        {
            _inAction = false;
        }
    }
}