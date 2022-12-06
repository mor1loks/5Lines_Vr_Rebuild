using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using AosSdk.Core.PlayerModule;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine.Events;


public class Teleporter : MonoBehaviour
{
    [SerializeField] private CameraFlash _cameraFlash;
    [SerializeField] private Transform _corridorFromFieldPosition;
    [SerializeField] private Transform _fieldPosition;
    [SerializeField] private Transform _corridorFromRelePosition;
    [SerializeField] private Transform _relePosition;
    [SerializeField] private Transform _corridorFromDspPosition;
    [SerializeField] private Transform _dspPosition;
    [SerializeField] private Transform _startPosition;

    private string _previousLocation;

    public void Teleport(string locationName)
    {
        if (locationName == "start")
            TeleportPlayer(_startPosition);

        if (locationName == "field" || locationName == "hall" || locationName == "dsp" || locationName == "relay_room")
        {
            if (_previousLocation == locationName)
                return;
            if (locationName == "hall" && _previousLocation == "dsp")
            {
                TeleportPlayer(_corridorFromDspPosition);
            }
            else if (locationName == "hall" && _previousLocation == "relay_room")
            {
                    TeleportPlayer(_corridorFromRelePosition);
            }
            else  if (locationName == "field")
            {
                    TeleportPlayer(_fieldPosition);
            }
            else if (locationName == "dsp")
            {
                    TeleportPlayer(_dspPosition);
            }
            else if (locationName == "relay_room")
            {
              TeleportPlayer(_relePosition);
            }
            else if (locationName == "hall")
            {
              TeleportPlayer(_corridorFromFieldPosition);
            }
            if (_previousLocation != locationName)
            {
                _previousLocation = locationName;
            }
        }
    }


    private void TeleportPlayer(Transform newPosition)
    {
        Player.Instance.TeleportTo(newPosition);
        _cameraFlash.CameraFlashStart();
    }
}