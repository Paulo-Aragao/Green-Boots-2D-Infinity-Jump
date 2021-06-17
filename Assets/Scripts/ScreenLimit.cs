using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenLimit : MonoBehaviour
{
    [SerializeField] private bool _right;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(_right){
                other.gameObject.transform.position = new Vector2(-1*GameManager.Instance.screenSize,other.gameObject.transform.position.y);
            }else{
                other.gameObject.transform.position = new Vector2(GameManager.Instance.screenSize,other.gameObject.transform.position.y);
            }
            
        }
        
    }
}
