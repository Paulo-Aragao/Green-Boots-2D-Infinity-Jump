using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Rokket : MonoBehaviour
{
    
    [SerializeField] private TouchInput _touchInputSystem;
    [SerializeField] private Slider _fuel_chager;
    [SerializeField] private TMP_Text _fuel_count_tmp;
    [SerializeField] private ParticleSystem[] _rokkets_fires;
    [SerializeField] private Renderer _rokket_status_lamp;
    
    private int _fuel = 10;
    private float _fuel_cool_down = 0;
    void Start()
    {
        _fuel_count_tmp.text = "1";
        _fuel = 1;
        _fuel_cool_down = Time.time + 0.05f;
    }
    // Update is called once per frame
    void Update()
    {
        if(_fuel > 0){
            _rokket_status_lamp.material.SetColor("_Color", Color.green);
        }else{
            _rokket_status_lamp.material.SetColor("_Color", Color.red);
        }
        if(_fuel == PlayerPrefs.GetInt("RokketLevel")){
            _fuel_chager.fillRect.gameObject.SetActive(false);
        }else{
            _fuel_chager.fillRect.gameObject.SetActive(true);
        } 
        if(Time.time > _fuel_cool_down && _fuel < PlayerPrefs.GetInt("RokketLevel")){
            if(_fuel_chager.value  < 100){
                _fuel_chager.value++;
            }
            _fuel_cool_down = Time.time + 0.05f;
        }
        if(_fuel_chager.value > 99){
            _fuel++;
            _fuel_count_tmp.text = _fuel.ToString();
            _fuel_chager.value = 0;
        }
        if(_touchInputSystem.GetDirection() != Vector2.zero && _fuel > 0){
            if(_touchInputSystem.GetDirection() == Vector2.up){
                _fuel--;
                Player.Instance.Jump();
                _fuel_count_tmp.text = _fuel.ToString();
                _rokkets_fires[0].Play();
                _rokkets_fires[1].Play();
            }
        }
        if (Input.GetKeyDown("space") && _fuel > 0)
        {
            _fuel--;
            Player.Instance.Jump();
            _fuel_count_tmp.text = _fuel.ToString();
            _rokkets_fires[0].Play();
            _rokkets_fires[1].Play();
        } 
    }
}
