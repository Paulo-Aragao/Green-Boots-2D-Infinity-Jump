using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowControll : MonoBehaviour
{
    private float _emission = 20;
    public void IncreaseSnow(){
        var main = gameObject.GetComponent<ParticleSystem>().main;
        var emission = gameObject.GetComponent<ParticleSystem>().emission;
        if(main.simulationSpeed < 2f){
            main.simulationSpeed += 0.05f;
        }
        if(_emission < 200f){
            _emission +=2;
            emission.rateOverTime = _emission;
        }
    }
    public void ResetSnow(){
        _emission = 20;
        var main = gameObject.GetComponent<ParticleSystem>().main;
        main.simulationSpeed = 1f;
        var emission = gameObject.GetComponent<ParticleSystem>().emission;
        emission.rateOverTime = _emission;
    }
}
