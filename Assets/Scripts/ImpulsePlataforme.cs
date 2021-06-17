using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpulsePlataforme : MonoBehaviour
{
    void Update()
    {
        if(Player.Instance.gameObject.transform.position.y > transform.position.y + 30){
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Player.Instance.Jump(2);
        Destroy(gameObject);
    }
}
