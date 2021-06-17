using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Transform[] _layers;
    [SerializeField] private float[] _mult;
    private Vector3[] _startPos;

    void Awake()
    {
        _startPos = new Vector3[_layers.Length];
        for (int i = 0; i < _layers.Length; i++)
        {
            _startPos[i] = _layers[i].position;
        }
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < _layers.Length; i++)
        {
            _layers[i].position = _startPos[i] + (_mult[i]/100) * (new Vector3(_layers[i].position.x,
                                                                    GameObject.FindGameObjectWithTag("MainCamera").transform.position.y,
                                                                    0));
        }
    }
}
