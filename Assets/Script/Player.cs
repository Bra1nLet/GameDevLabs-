using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.UIElements;
using UnityEngine;
 

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private Transform _transform;
    [Header("HorizontalMovement")]
    [SerializeField] private float HorizonstalSpeed;
    [SerializeField] private bool FacePosition;
    
    
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
        if (direction == -1)
        {
            HFlip();
            _animator.SetInteger("Direction", 3);
        }
        else if (direction == 1)
        {
            _animator.SetInteger("Direction", 2);
            HFlip();
        }
    }
    
    public void VMove(float direction)
    {
        Vector2 velocity = _rigidbody2D.velocity;
        velocity.y = direction * HorizonstalSpeed;
        _rigidbody2D.velocity = velocity;
        if (direction == 1)
        {
            VFlip();
            _animator.SetInteger("Direction", 1);
        }
        else if (direction == -1)
        {
            VFlip();
            _animator.SetInteger("Direction", 0);
        }
    }
    
    public void VFlip()
    {
        FacePosition = !FacePosition;
    }
    
    public void HFlip()
    {
        FacePosition = !FacePosition;
    }
}
