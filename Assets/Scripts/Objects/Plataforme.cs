using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforme : MonoBehaviour
{
    [SerializeField] private GameObject _coin;
    void OnEnable()
    {
        PlayerPrefs.SetInt("CoinFrequency",30);
        int coin_active_rand = Random.Range(0,100);
        if(coin_active_rand < PlayerPrefs.GetInt("CoinFrequency")){
            _coin.SetActive(true);
        }
    }
   // Update is called once per frame
    void Update()
    {
        if(Player.Instance.gameObject.transform.position.y > transform.position.y){
            Invoke("EnableCollider",0.1f);
        }
        else{
            GetComponent<BoxCollider2D>().enabled = false;
        }  
        if(Player.Instance.gameObject.transform.position.y > transform.position.y + 30){
            Destroy(gameObject);
        } 
    }
    private void EnableCollider(){
        GetComponent<BoxCollider2D>().enabled = true;
    }
}
