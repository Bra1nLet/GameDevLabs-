using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.UIElements;
using UnityEngine;
using Random = UnityEngine.Random;


public class ScrollEffects : MonoBehaviour
{
    [SerializeField] private GameObject S1;
    [SerializeField] private GameObject S2;
    [SerializeField] private GameObject S3;
    [SerializeField] private GameObject S4;

    [SerializeField] private float max_gap;
    
    // Start is called before the first frame update  
    void Start()
    {
        S1 = Instantiate(S1);
        S2 = Instantiate(S2);
        S3 = Instantiate(S3);
        S4 = Instantiate(S4);
        
        S1.transform.position = new Vector2(transform.position.x, transform.position.y + 0.4f);
        
        S2.transform.position = new Vector2(transform.position.x + 0.2f, transform.position.y + 0.2f);
        
        S3.transform.position = new Vector2(transform.position.x + 0.5f, transform.position.y + 0.7f);
        
        S4.transform.position = new Vector2(transform.position.x + -0.3f, transform.position.y + 0.5f);
    }

    // Update is called once per frame

 
    void FixedUpdate()
    {
        Ani(S1, 0f);
        Ani(S2, 0.2f);
        Ani(S3, 0.5f);
        Ani(S4, -0.3f);
 
        S1.transform.position = new Vector2(S1.transform.position.x, S1.transform.position.y + 0.01f);
        S2.transform.position = new Vector2(S2.transform.position.x, S2.transform.position.y + 0.01f);
        S3.transform.position = new Vector2(S3.transform.position.x, S3.transform.position.y + 0.01f);
        S4.transform.position = new Vector2(S4.transform.position.x, S4.transform.position.y + 0.01f);
    }
    public void Ani(GameObject S, float gap_x)
    {
        if (S.transform.position.y > transform.position.y + max_gap)
        {
            S.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1,S.GetComponent<SpriteRenderer>().color.a - 0.1f);
            if (S.GetComponent<SpriteRenderer>().color.a <= 0)
            {
                S.transform.position = new Vector2(transform.position.x + gap_x, transform.position.y + Random.Range(0.2f, 0.7f));
                S.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1,1);
            }
        }
    }
}
