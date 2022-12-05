using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
public class LocationController : MonoBehaviour
{

    [SerializeField] private API _api;
    [SerializeField] private LocationText _locationText;
    [SerializeField] private ConnectionChecker _connectionChecker;
    private string _currentLocation = "field";
    private void OnEnable()
    {
        _api.OnSetNewLocationText += OnSetLocationtext;
        _api.OnSetLocation += OnSetLocation;
        _connectionChecker.OnConnectionReady += OnConnectionEstablished;
    }
    private void OnDisable()
    {
        _api.OnSetNewLocationText -= OnSetLocationtext;
        _api.OnSetLocation += OnSetLocation;
        _connectionChecker.OnConnectionReady -= OnConnectionEstablished;
    }
    private void OnSetLocationtext(string text)
    {
        _locationText.SetLocationText(text);
    }

    private void OnConnectionEstablished()
    {
        _api.ConnectionEstablished(_currentLocation);
    }
    private void OnSetLocation(string location)
    {
        _currentLocation = location;
        StreetCollidersActivator.Instance.ActivateColliders(location);
    }
    public string GetLocationName() => _currentLocation;

}
