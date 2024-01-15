using UnityEngine;
public class LocationController : MonoBehaviour
{
    [SerializeField] private API _api;
    [SerializeField] private BaseTextObject _locationText;
    private string _currentLocation = "field";
    public void SetLocationtext(string text)
    {
        _locationText.SetText(text);
    }
    public void ConnectionEstablished()
    {
        _api.ConnectionEstablished(_currentLocation);
    }
    public void SetLocation(string location)
    {
        _currentLocation = location;
        StreetCollidersActivator.Instance.ActivateColliders(location);
    }
    public string GetLocationName() => _currentLocation;
}
