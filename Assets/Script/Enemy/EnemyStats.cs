using System;
using Cinemachine;
using Cinemachine.Utility;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

namespace Enemy
{
    public class EnemyStats : MonoBehaviour
    {
        [SerializeField] public float health;

        private void FixedUpdate()
        {
            if (health <= 0)
            {  
                Destroy(gameObject);
            }
            
        }   
        
    }
}