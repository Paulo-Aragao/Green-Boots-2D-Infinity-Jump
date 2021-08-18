using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAndPlayGame : MonoBehaviour
{
    [SerializeField] private GameObject _pause_button;
    [SerializeField] private GameObject _play_button;
    
    public void PauseGame ()
    {
        _pause_button.SetActive(false);
        _play_button.SetActive(true);
        SoundManager.Instance.PauseSound();
        Time.timeScale = 0;
    }

    public void ResumeGame ()
    {
        _pause_button.SetActive(true);
        _play_button.SetActive(false);
        SoundManager.Instance.ResumeSound();
        Time.timeScale = 1;
    }
}
