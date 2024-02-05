using UnityEngine;
public class LocationController : MonoBehaviour
{
    [SerializeField] private API _api;
    private string _currentLocation = "field";
    public void ConnectionEstablished()
    {
        _api.InvokeEndTween(_currentLocation);
    }
    public void SetLocation(string location)
    {
        _currentLocation = location;
        StreetCollidersActivator.Instance.ActivateColliders(location);
    }
    public string CurrentLocation() => _currentLocation;
    public string BackLocation { get; set; }
}

