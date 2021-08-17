using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{   
    void Update()
    {
        if(Player.Instance.gameObject.transform.position.y > transform.position.y + 30){
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.AddCoin();
            AudioClip sfx = Resources.Load("sounds/SFX/coin") as AudioClip;
            SoundManager.Instance.PlaySoundOnce(sfx);
            gameObject.SetActive(false);
        }
        
    }
}
