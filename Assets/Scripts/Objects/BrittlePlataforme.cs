using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrittlePlataforme : Plataforme
{
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        //Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}
