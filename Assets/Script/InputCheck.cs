using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCheck : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Player _player;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _player.HMove(Input.GetAxisRaw("Horizontal"));
        _player.VMove(Input.GetAxisRaw("Vertical"));
    }
    
    
}
