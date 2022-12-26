using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public static SoundPlayer Instance;
    [SerializeField] private AudioClip _tapButtonSound, _mapOpenSound, _mapCloseSound, _radioSound, _stoneSound,_doorSound,_railNormalSound,_railNoSound,_railFriktSound, _railStoneSound;

    private AudioSource _audioSource;
    private void Awake()
    {
        if(Instance==null)
            Instance = this;
    }
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public void PlayTapSound()
    {
        _audioSource.PlayOneShot(_tapButtonSound);
    }
    public void PlayMapOpenSound()
    {
        _audioSource.PlayOneShot(_mapOpenSound);
    }
    public void PlayMapCloseSound()
    {
        _audioSource.PlayOneShot(_mapCloseSound);
    }
    public void PlayRadioSound()
    {
        _audioSource.PlayOneShot(_radioSound);
    }
    public void PlayStoneSound()
    {
        _audioSource.PlayOneShot(_stoneSound);
    }
    public void PlayDoorSound()
    {
        _audioSource.PlayOneShot(_doorSound);
    }
    public void PlayRailNormSound()
    {
        _audioSource.PlayOneShot(_railNormalSound);
    }
    public void PlayRailNoSound()
    {
        _audioSource.PlayOneShot(_railNoSound);
    }
    public void PlayRailFriktSound()
    {
        _audioSource.PlayOneShot(_railFriktSound);
    }
    public void PlayRailStoneSound()
    {
        _audioSource.PlayOneShot(_railStoneSound);
    }
}
