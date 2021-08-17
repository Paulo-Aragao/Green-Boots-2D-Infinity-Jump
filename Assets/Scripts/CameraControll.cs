using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    private Transform _startMarker;
    private Transform _endMarker;
    // Movement speed in units per second.
    [SerializeField] private float _speed = 1.0F;
    // Time when the movement started.
    private float _startTime;
    private Vector3 _targetPosition;
    public float maxHeight;
    // Total distance between the markers.
    private float _journeyLength;
     void Start()
    {
        maxHeight = 0;
        _startMarker = transform;
        _endMarker = Player.Instance._pointCam.transform;
        // Keep a note of the time the movement started.
        _startTime = Time.time;

        // Calculate the journey length.
        _journeyLength = Vector3.Distance(_startMarker.position, _endMarker.position);
    }

    // Move to the target end position.
    void Update()
    {
        if(GameManager.Instance.GetGameIsRunning()){
            if(transform.position.y > maxHeight){
            maxHeight = maxHeight+2;
            }
            if(_endMarker.position.y > maxHeight){
                // Distance moved equals elapsed time times speed..
                float distCovered = Time.deltaTime * _speed;
                // Fraction of journey completed equals current distance divided by total distance.
                float fractionOfJourney = distCovered / _journeyLength;
                // Set our position as a fraction of the distance between the markers.
                _targetPosition = Vector3.Lerp(_startMarker.position, _endMarker.position , fractionOfJourney);
                transform.position = new Vector3(transform.position.x,_targetPosition.y,transform.position.z);
            }
        }
        
    }
}
