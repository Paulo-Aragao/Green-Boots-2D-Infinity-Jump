using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _new_coins;
    [SerializeField] private TMP_Text _coins;
    [SerializeField] private TMP_Text _height_final;
    [SerializeField] private GameObject _new_record_pop_up;
    [SerializeField] private GameObject _restart_bt;
    //
    private bool _calculating = true;
    private int _current_coins = 0;
    private int _total_coins = 0;
    void OnEnable()
    {
        _restart_bt.SetActive(false);
        _calculating = true;
        _current_coins = PlayerPrefs.GetInt("Coins");
        _total_coins = PlayerPrefs.GetInt("Coins")+GameManager.Instance.GetCoins();
        _new_coins.text ="+" + GameManager.Instance.GetCoins().ToString();
        _height_final.text = GameManager.Instance.GetHeight().ToString();
        if(GameManager.Instance.GetHeight() > PlayerPrefs.GetInt("Coins")){
            _new_record_pop_up.SetActive(true);
        }else{
            _new_record_pop_up.SetActive(false);
        }
    }
    void Update()
    {
        if(_calculating){
            if(_current_coins <= _total_coins){
                _current_coins++;
                PlayerPrefs.SetInt("Coins",PlayerPrefs.GetInt("Coins")+1);
                _coins.text = PlayerPrefs.GetInt("Coins").ToString();
            }else{
                _restart_bt.SetActive(true);
                _calculating = false;
                gameObject.GetComponent<Market>().RefreshValues();
            }
        }
    }
}
