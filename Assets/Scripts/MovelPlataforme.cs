using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovelPlataforme : Plataforme
{
    [SerializeField] private float _speed = 1;
    [SerializeField] private string _orientation = "horizontal";
    private int _direction = 1;
    private Vector3 _startPos;
    void Update()
    {
        
        if(_orientation == "horizontal"){
            if(transform.position.x > GameManager.Instance.screenSize-1){
                _direction = -1;
            }else if(transform.position.x < (GameManager.Instance.screenSize-1)*-1){
                _direction = 1;
            }
            transform.position = transform.position + (Vector3.right* _speed * Time.deltaTime * _direction);
        }else{
            if(transform.position.y > (_startPos.y + 5)){
                _direction = -1;
            }else if(transform.position.y < (_startPos.y - 5)){
                _direction = 1;
            }
            transform.position = transform.position + (Vector3.up* _speed * Time.deltaTime * _direction);
        }
        
    }
}
