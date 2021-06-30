using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Market : MonoBehaviour
{
    [SerializeField] private TMP_Text _new_coins;
    [SerializeField] private TMP_Text _coins;
    [SerializeField] private TMP_Text _height_final;
    [SerializeField] private GameObject _new_record_pop_up;
    [SerializeField] private TMP_Text _fashion_cost;
    [SerializeField] private TMP_Text _rokket_cost;
    [SerializeField] private TMP_Text _coin_plus_cost;

    void OnEnable()
    {
        _coins.text = PlayerPrefs.GetInt("Coins").ToString();
        _new_coins.text ="+" + GameManager.Instance.GetCoins().ToString();
        _height_final.text = GameManager.Instance.GetHeight().ToString();
        
        if(GameManager.Instance.GetHeight() > PlayerPrefs.GetInt("Coins")){
            _new_record_pop_up.SetActive(true);
        }else{
            _new_record_pop_up.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
