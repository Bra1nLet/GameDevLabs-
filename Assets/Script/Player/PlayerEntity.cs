using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.UIElements;
using UnityEngine;

namespace Player
{
    public class PlayerEntity : MonoBehaviour
    {
        // Start is called before the first frame update
        private Rigidbody2D _rigidbody2D;
        private Animator _animator;
        private Transform _transform;

        [Header("HorizontalMovement")] [SerializeField]
        private float HorizonstalSpeed;

        [SerializeField] private float damage;

        [SerializeField] private bool FacePosition;

        [SerializeField] private GameObject Projectile;


        [SerializeField] private float _gravityScale;

        void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _transform = GetComponent<Transform>();
            _animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {

        }
    

        public void HMove(float direction)
        {
            Vector2 velocity = _rigidbody2D.velocity;
            velocity.x = direction * HorizonstalSpeed;
            _rigidbody2D.velocity = velocity;
            if (direction < 0)
            {
                _animator.SetInteger("Direction", 3);
            }
            else if (direction > 0)
            {
                _animator.SetInteger("Direction", 2);
            }
        }

        public void VMove(float direction)
        {
            Vector2 velocity = _rigidbody2D.velocity;
            velocity.y = direction * HorizonstalSpeed;
            _rigidbody2D.velocity = velocity;
            if (direction < -0.5f)
            {
                _animator.SetInteger("Direction", 0);
            }
            else if (direction > 0.5f)
            {
                _animator.SetInteger("Direction", 1);
            }
        }
        

        public void Attack()
        {
            Projectile.transform.position = gameObject.transform.position;
            Projectile.GetComponent<Projectile.Projectile>().damage = damage;
            GameObject project = Instantiate(Projectile);
        }
    }
}