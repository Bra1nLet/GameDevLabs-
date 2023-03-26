using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class ExternalDevicesInputReader : IEntityInputSource
{
    // Start is called before the first frame update
    public float HorizontalDirection => Input.GetAxisRaw("Horizontal");
    public float VerticalDirection => Input.GetAxisRaw("Vertical");
    public bool Attack { get; private set; }
     
 

    public void OnUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack = true;
        }
    }
    
    public void ResetOneTimeActions()
    {
        Attack = false;
    }
    

}
