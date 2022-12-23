using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticSoundsPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip _dspSound, _relaySound, _fieldSound, koridSound;
    private AudioSource _audioSource;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public void PlayDspSound()
    {
        _audioSource.PlayOneShot(_dspSound);
    }
    public void PlayRelayOpenSound()
    {
        _audioSource.PlayOneShot(_relaySound);
    }
    public void PlayFieldSound()
    {
        _audioSource.PlayOneShot(_fieldSound);
    }
    public void PlayKoridSound()
    {
        _audioSource.PlayOneShot(koridSound);
    }
    public void StopSoundPlayer()
    {
        _audioSource.Stop();
    }
}
