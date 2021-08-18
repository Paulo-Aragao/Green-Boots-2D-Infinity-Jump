using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Rokket : MonoBehaviour
{
    
    [SerializeField] private TouchInput _touchInputSystem;
    [SerializeField] private ParticleSystem[] _rokkets_fires;
    [SerializeField] private Renderer _rokket_status_lamp;
    [SerializeField] private GameObject[] _fuel_icons;
    private int _fuel = 10;
    private float _fuel_cool_down = 0;
    [SerializeField] private float _cool_down_value = 1.5f;
    void Start()
    {
        _fuel = 1;
        _fuel_cool_down = Time.time + _cool_down_value;
    }
    // Update is called once per frame
    void Update()
    {
        //color of head rokket
        if(_fuel > 0){
            _rokket_status_lamp.material.SetColor("_Color", Color.green);
        }else{
            _rokket_status_lamp.material.SetColor("_Color", Color.red);
        }
        if(Time.time > _fuel_cool_down && _fuel < PlayerPrefs.GetInt("RokketLevel")){
            _fuel_cool_down = Time.time + _cool_down_value;
            _fuel_icons[_fuel].SetActive(true);
            _fuel++;
        }
        if(_touchInputSystem.GetDirection() != Vector2.zero && _fuel > 0){
            if(_touchInputSystem.GetDirection() == Vector2.up){
                _fuel--;
                Player.Instance.Jump();
                _rokkets_fires[0].Play();
                _rokkets_fires[1].Play();
                AudioClip sfx = Resources.Load("sounds/SFX/rokket") as AudioClip;
                SoundManager.Instance.PlaySoundOnce(sfx);
                _fuel_icons[_fuel].SetActive(false);
                _fuel_cool_down = Time.time + _cool_down_value;
            }
        }
        if (Input.GetKeyDown("space") && _fuel > 0)
        {
            AudioClip sfx = Resources.Load("sounds/SFX/rokket") as AudioClip;
            SoundManager.Instance.PlaySoundOnce(sfx);
            _fuel--;
            Player.Instance.Jump();
            _rokkets_fires[0].Play();
            _rokkets_fires[1].Play();
            _fuel_icons[_fuel].SetActive(false);
            _fuel_cool_down = Time.time + _cool_down_value;
        } 
    }
}
