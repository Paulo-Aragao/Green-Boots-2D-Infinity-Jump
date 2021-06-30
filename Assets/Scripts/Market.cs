using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Market : MonoBehaviour
{
    [SerializeField] private TMP_Text _fashion_cost_tmp;
    [SerializeField] private TMP_Text _rokket_cost_tmp;
    [SerializeField] private TMP_Text _coin_plus_cost_tmp;
    [SerializeField] private GameObject _fashion_cost_upgrade_bt;
    [SerializeField] private GameObject _rokket_cost_upgrade_bt;
    [SerializeField] private GameObject _coin_plus_cost_upgrade_bt;
    [SerializeField] private int[] _fashion_cost_values;
    [SerializeField] private int[] _rokket_cost_values;
    [SerializeField] private int[] _coin_plus_cost_values;
    [SerializeField] private TMP_Text _total_coins;
    void OnEnable()
    {
        /*
        //fashion item
        if(GameManager.Instance.GetFashionLevel == 1){
            _fashion_cost.text = _fashion_cost_values[0].ToString();
        }else if(GameManager.Instance.GetFashionLevel == 2){
            _fashion_cost.text = _fashion_cost_values[1].ToString();
        }else{
            _fashion_cost.text = _fashion_cost_values[2].ToString();
        } 
        //rokket item
        if(GameManager.Instance.GetRokketLevel == 1){
            _fashion_cost.text = _rokket_cost_values[0].ToString();
        }else if(GameManager.Instance.GetFashionLevel == 2){
            _fashion_cost.text = _rokket_cost_values[1].ToString();
        }else{
            _fashion_cost.text = _rokket_cost_values[2].ToString();
        }  
        //coin plus item
        if(GameManager.Instance.GetCoinPlusLevel == 1){
            _fashion_cost.text = _coin_plus_cost_values[0].ToString();
        }else if(GameManager.Instance.GetFashionLevel == 2){
            _fashion_cost.text = _coin_plus_cost_values[1].ToString();
        }else{
            _fashion_cost.text = _coin_plus_cost_values[2].ToString();
        }*/
        RefreshValues();
    }
    private void RefreshValues(){
        DefineCostItem(ref _fashion_cost_tmp,_fashion_cost_values,GameManager.Instance.GetFashionLevel());
        DefineCostItem(ref _rokket_cost_tmp,_rokket_cost_values,GameManager.Instance.GetRokketLevel());
        DefineCostItem(ref _coin_plus_cost_tmp,_coin_plus_cost_values,GameManager.Instance.GetCoinPlusLevel());
        MoneyVerification();
    }
    private void DefineCostItem(ref TMP_Text tmp, int[] costs,int level){
        if(level == 1){
            tmp.text = costs[0].ToString();
        }else if(level == 2){
            tmp.text = costs[1].ToString();
        }else{
            tmp.text = costs[2].ToString();
        } 
    }
    private void MoneyVerification(){
        //money verification
        if(PlayerPrefs.GetInt("Coins") > _fashion_cost_values[GameManager.Instance.GetFashionLevel()-1]){
            _fashion_cost_upgrade_bt.SetActive(true);
        }else{
            _fashion_cost_upgrade_bt.SetActive(false);
        }
        if(PlayerPrefs.GetInt("Coins") > _rokket_cost_values[GameManager.Instance.GetFashionLevel()-1]){
            _rokket_cost_upgrade_bt.SetActive(true);
        }else{
            _rokket_cost_upgrade_bt.SetActive(false);
        }
        if(PlayerPrefs.GetInt("Coins") > _coin_plus_cost_values[GameManager.Instance.GetFashionLevel()-1]){
            _coin_plus_cost_upgrade_bt.SetActive(true);
        }else{
            _coin_plus_cost_upgrade_bt.SetActive(false);
        }
    }
    public void BuyFashion(){
        PlayerPrefs.SetInt("Coins",PlayerPrefs.GetInt("Coins")-_fashion_cost_values[GameManager.Instance.GetFashionLevel()-1]);
        _total_coins.text = PlayerPrefs.GetInt("Coins").ToString();
        GameManager.Instance.SetFashionLevel(GameManager.Instance.GetFashionLevel()+1);
        PlayerPrefs.SetInt("FashionLevel",GameManager.Instance.GetFashionLevel());
        RefreshValues();
    }
    public void BuyRokket(){
        PlayerPrefs.SetInt("Coins",PlayerPrefs.GetInt("Coins")-_rokket_cost_values[GameManager.Instance.GetFashionLevel()-1]);
        _total_coins.text = PlayerPrefs.GetInt("Coins").ToString();
        GameManager.Instance.SetRokketLevel(GameManager.Instance.GetRokketLevel()+1);
        PlayerPrefs.SetInt("RokketLevel",GameManager.Instance.GetRokketLevel());
        RefreshValues();
    }
    public void BuyCoinPlus(){
        PlayerPrefs.SetInt("Coins",PlayerPrefs.GetInt("Coins")-_coin_plus_cost_values[GameManager.Instance.GetFashionLevel()-1]);
        _total_coins.text = PlayerPrefs.GetInt("Coins").ToString();
        GameManager.Instance.SetCoinPlusLevel(GameManager.Instance.GetCoinPlusLevel()+1);
        PlayerPrefs.SetInt("CoinPlusLevel",GameManager.Instance.GetCoinPlusLevel());
        RefreshValues();
    }
}
