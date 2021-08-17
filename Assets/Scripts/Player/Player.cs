using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce = 1;
    public float moveForce = 1;
    private Rigidbody2D _rb;
    private float moveInput;
    public GameObject _pointCam;
    private static Player _instance;
    public static Player Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.FindObjectOfType<Player>();
            }

            return _instance;
        }
    }
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        
    }
    private void Start() {
        _rb = GetComponent<Rigidbody2D>();
    }
    public void Jump(int force = 1){
        //gameObject.GetComponent<Animator>().SetTrigger("Jump");
        Vector3 vel = _rb.velocity;
        vel.y = 0;
        _rb.velocity = vel;
        _rb.AddForce(transform.up * jumpForce *force, ForceMode2D.Impulse);
        
    }
    void Update()
    {
        if(_rb.velocity.y < 0f){
            gameObject.GetComponent<Animator>().SetBool("Fallen",true);
        }else{
            gameObject.GetComponent<Animator>().SetBool("Fallen",false);

        }
    }
     void FixedUpdate()
    {
        Vector2 acc = Input.acceleration;
        _rb.velocity = new Vector2(acc.x * moveForce *5, _rb.velocity.y);
        moveInput = Input.GetAxis("Horizontal");
        if(moveInput != 0){
            _rb.velocity = new Vector2(moveInput * moveForce, _rb.velocity.y);
        }
    }
}
