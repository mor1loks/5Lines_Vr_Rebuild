using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticSoundsPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip  _relaySound, _fieldSound;
    private AudioSource _audioSource;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public void PlayRelaySound()
    {
        _audioSource.PlayOneShot(_relaySound);
    }
    public void PlayFieldSound()
    {
        _audioSource.PlayOneShot(_fieldSound);
    }
    public void StopSoundPlayer()
    {
        _audioSource.Stop();
    }
}
