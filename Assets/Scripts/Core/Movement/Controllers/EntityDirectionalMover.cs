using StatsSystem;
using UnityEngine;

namespace Core.Movement.Controllers
{
    public class EntityDirectionalMover
    {
        private readonly Rigidbody2D _rigidbody;
 
        private readonly IStatValueGiver _statValueGiver;
        
 
        private Vector2 _velocity;
        
        public bool FacingRight { get; private set; }
        public bool IsMoving => _velocity.magnitude > 0;

        public EntityDirectionalMover(Rigidbody2D rigidbody, IStatValueGiver statValueGiver)
        {
            _rigidbody = rigidbody;
            _statValueGiver = statValueGiver;
         
        }

        public float GetHSpeed() => _velocity.x;
        public float GetVSpeed() => _velocity.y;
        
        public void MoveHorizontally(float horizontalDirection)
        {
            _velocity.x = horizontalDirection;
            SetDirection(horizontalDirection);
            var velocity = _rigidbody.velocity;
            velocity.x = horizontalDirection * _statValueGiver.GetStatValue(StatType.Speed);
            _rigidbody.velocity = velocity;
        }
    
        public void MoveVertically(float verticalDirection)
        {
            _velocity.y = verticalDirection;
            var velocity = _rigidbody.velocity;
            velocity.y = verticalDirection * _statValueGiver.GetStatValue(StatType.Speed);
            _rigidbody.velocity = velocity;
            
            if (verticalDirection == 0)
                return;
        }

     
        
    
        
        private void SetDirection(float direction)
        {
            switch (direction)
            {
                case < 0 when FacingRight:
                    
                case > 0 when !FacingRight:
                    Flip();
                    break;
            }
        }

        private void Flip()
        {
            FacingRight = !FacingRight;
            
            //_rigidbody.transform.Rotate(0,180,0);
        }
    }
}