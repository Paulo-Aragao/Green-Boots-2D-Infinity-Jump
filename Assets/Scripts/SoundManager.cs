using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public AudioClip _main_loop;
	private static SoundManager _instance;
    public static SoundManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.FindObjectOfType<SoundManager>();
            }

            return _instance;
        }
    }
	void Start()
	{
		PlaySoundLoop(_main_loop);
	}
    public void PlaySoundOnce (AudioClip audioClip)
    {
            StartCoroutine (PlaySoundCoroutine (audioClip));
    }

    private IEnumerator PlaySoundCoroutine (AudioClip audioClip)
    {
            GetComponent<AudioSource>().PlayOneShot (audioClip);
            yield return new WaitForSeconds (audioClip.length);
            //Destroy (gameObject);
    }

    public void PlaySoundLoop (AudioClip audioClip)
    {
            GetComponent<AudioSource>().clip = audioClip;
            GetComponent<AudioSource>().loop = true;
            GetComponent<AudioSource>().Play ();
    }

    public void StopSound ()
    {
            GetComponent<AudioSource>().Stop ();
            Destroy (gameObject);
    }
	
}

