using System;
using Cinemachine.Utility;
using Enemy;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

namespace Projectile
{
    public class Projectile : MonoBehaviour
    {
        private Vector2 StartPos;
        private Vector3 check;
        Rigidbody2D _rbRigidbody2D;
        LineRenderer _lineRenderer;
        Animator _animator;
        public float damage;
        void Awake()
        {
            _rbRigidbody2D = this.GetComponent<Rigidbody2D>();
            _lineRenderer = this.GetComponent<LineRenderer>();
            _animator = this.GetComponent<Animator>();
            StartPos = transform.position;
            check = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Throw();
        }
        
        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.layer == 6)
            {
                col.gameObject.GetComponent<EnemyStats>().health -= damage;
            }
            _rbRigidbody2D.Sleep();
            _animator.Play("Destroy");
        }
        private void FixedUpdate()
        {
             
            if (Vector2.Distance(StartPos, transform.position) > 15)
            {
                Destroy(gameObject);
            }
        }
        public void Destroy_it()
        {
            Destroy(gameObject);
        }
        public void Throw()
        {
            Debug.DrawRay(transform.position, check - transform.position, Color.red );
            _rbRigidbody2D.AddForce((check - transform.position)*5 , ForceMode2D.Impulse);
        }
    }           
}