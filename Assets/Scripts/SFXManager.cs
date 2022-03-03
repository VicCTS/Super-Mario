using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    //clip de audio para la muerte de mario
    public AudioClip deathSFX;
    //clip de audio muerte goomba
    public AudioClip goombaSFX;
    //clip para el audio de la moneda
    public AudioClip monedaSFX;


    //Variable del audio source
    private AudioSource _audioSource;
    
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    
    public void DeathSound()
    {
        _audioSource.PlayOneShot(deathSFX);
    }

    public void GoombaSound()
    {
        _audioSource.PlayOneShot(goombaSFX);
    }

    public void MonedaSound()
    {
        _audioSource.PlayOneShot(monedaSFX);
    }
}
