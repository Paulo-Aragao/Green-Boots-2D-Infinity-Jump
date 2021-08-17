using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TempControll : MonoBehaviour
{
    [SerializeField] private Image _freezeFilterOverScreen; 
    [SerializeField] private Image _tempBar; 
    [SerializeField] private Image _tempBarBall; 
    [SerializeField] private Slider _temp_slider;
    //private int _temp = 100;
    private Color _color_aux;
    private bool _incrementing = true;
    [SerializeField] private float _delay;
    [SerializeField] private float _delay_temp;
    private float _cool_down_delay;
    private float _cool_down_temp;
    void Start()
    {
        _delay = _delay/100;
        _delay_temp = _delay_temp/100;
        _cool_down_delay = Time.time + _delay;
        _cool_down_temp = Time.time + _delay_temp;
    }
    // Update is called once per frame
    void Update()
    {   
        if(GameManager.Instance.GetHeight() > 500+(PlayerPrefs.GetInt("FashionLevel")*500) && Time.time > _cool_down_delay){
            _color_aux = Player.Instance.gameObject.GetComponent<Renderer>().material.GetColor("_Color");
            if(_color_aux.r > 0.9f){
                _incrementing = false;
            }else if(_color_aux.r < 0.1f){
                _incrementing = true;
            }
            if(_incrementing){
                _color_aux.r += 0.05f;
            }else{
                _color_aux.r -= 0.05f;
            }
            Player.Instance.gameObject.GetComponent<Renderer>().material.SetColor("_Color",_color_aux);
            if( Time.time > _cool_down_temp){
                _cool_down_temp = Time.time + _delay_temp;
                _temp_slider.value -= 1;
                if(_temp_slider.value == 1){
                    _temp_slider.value = 100;
                    _color_aux = Player.Instance.gameObject.GetComponent<Renderer>().material.GetColor("_Color"); 
                    _color_aux.r = 1f;
                    Player.Instance.gameObject.GetComponent<Renderer>().material.SetColor("_Color",_color_aux);
                    _color_aux = _freezeFilterOverScreen.color;
                    _color_aux.a = 0f;
                    _freezeFilterOverScreen.color = _color_aux;
                    GameManager.Instance.GameOver();
                }
                if(_temp_slider.value < 50){
                    _tempBarBall.color = new Color(63f/255f,208f/255f,212f/255f,1f);
                    _tempBar.color = new Color(63f/255f,208f/255f,212f/255f,1f);
                }else{
                    _tempBarBall.color = Color.red;
                    _tempBar.color = Color.red;
                }
            }
        }
        if(Time.time > _cool_down_delay){
            _cool_down_delay = Time.time + _delay;
            if(_temp_slider.value < 50 ){
                _color_aux = _freezeFilterOverScreen.color;
                if(_color_aux.a > 0.7f){
                    _incrementing = false;
                }else if(_color_aux.a < 0.1f){
                    _incrementing = true;
                }
                if(_incrementing){
                    _color_aux.a += 0.01f;
                }else{
                    _color_aux.a -= 0.01f;
                }
                _freezeFilterOverScreen.color = _color_aux;
            }
        }
        
    }
}
