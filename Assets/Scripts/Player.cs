using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce = 1;
    public float moveForce = 1;
    private Rigidbody2D _rb;
    private float moveInput;
    [SerializeField] private TouchInput _touchInputSystem;
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
        Vector3 vel = _rb.velocity;
        vel.y = 0;
        _rb.velocity = vel;
        _rb.AddForce(transform.up * jumpForce *force, ForceMode2D.Impulse);
    }
    void Update()
    {
        if(_touchInputSystem.GetDirection() != Vector2.zero){
            if(_touchInputSystem.GetDirection() == Vector2.up){
                Jump();
            }
            Debug.Log("a");
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
