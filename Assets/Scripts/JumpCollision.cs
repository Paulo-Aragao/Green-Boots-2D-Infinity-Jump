using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Plataforme"))
        {
            Player.Instance.Jump();
        }
    }
}
