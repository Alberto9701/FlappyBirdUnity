using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    public static SoundSystem instance;
    /*
     * estos clips ya no los necesitaremos 
     * ya que les hemos hecho un audio source
     * para cada uno de los sonidos
    public AudioClip audioClipCoin;
    public AudioClip audioClipFlap;
    public AudioClip audioClipHit;*/

    public AudioSource audioSourceCoin;
    public AudioSource audioSourceFlap;
    public AudioSource audioSourceHit;



    private void Awake()
    {
        if (SoundSystem.instance == null)
        {
            SoundSystem.instance = this;
        }
        else if (SoundSystem.instance != this)
        {
            Destroy(gameObject);
        }
        SoundSystem.instance = this;

    }

    public void PlayCoin()
    {
        audioSourceCoin.Play();
    }

    public void PlayFlap()
    {
        audioSourceFlap.Play();
    }

    public void PlayHit()
    {
        audioSourceHit.Play();
    }



    private void OnDestroy()
    {
        if (SoundSystem.instance == this)
        {
            SoundSystem.instance = null;
        }
    }
}
