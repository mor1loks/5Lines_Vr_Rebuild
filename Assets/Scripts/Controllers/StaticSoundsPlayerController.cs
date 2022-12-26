using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticSoundsPlayerController : MonoBehaviour
{
    [SerializeField] private StaticSoundsPlayer _staticSounds;
    [SerializeField] private Teleporter _teleporter;
    private void OnEnable()
    {
        _teleporter.OnTeleportEnd += OnPlayStaticSond;
    }
    private void OnDisable()
    {
        _teleporter.OnTeleportEnd -= OnPlayStaticSond;
    }
    private void OnPlayStaticSond(string soundName)
    {
        if (soundName == "start" || soundName == "field")
        {
            _staticSounds.StopSoundPlayer();
            _staticSounds.PlayFieldSound();
        }
       else if(soundName == "hall")
            _staticSounds.StopSoundPlayer();
        else if(soundName == "dsp")
            _staticSounds.StopSoundPlayer();
        else if(soundName == "relay_room")
        {
            _staticSounds.StopSoundPlayer();
            _staticSounds.PlayRelaySound();
        }
          
    }
}
