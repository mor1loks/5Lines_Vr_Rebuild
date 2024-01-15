using AosSdk.Core.Utils;
using UnityEngine;

public class ModeController : MonoBehaviour
{
    [SerializeField] private AosSDKSettings _aosSettings;
    [SerializeField] private GameObject _desktopPlayer;
    [SerializeField] private GameObject _vrPlayer;

    [SerializeField] private BaseStartScreenView _desktopStartScreenView;
    [SerializeField] private BaseStartScreenView _vrStartScreenView;

    public BaseStartScreenView CurrentStartScreen { get; set; }

    private LaunchMode _currentMode;
    public bool DesktopMode => _currentMode == LaunchMode.Desktop;
    private void Start()
    {
        _currentMode = _aosSettings.launchMode;
        EnableObjectsByMode();
    }
    public Transform GetPlayerTransform()
    {
        if (_currentMode == LaunchMode.Vr)
            return _vrPlayer.transform;
        else if (_currentMode == LaunchMode.Desktop)
            return _desktopPlayer.transform;
        return null;
    }
    private void EnableObjectsByMode()
    {
       if(DesktopMode)
        {
            CurrentStartScreen = _desktopStartScreenView;
        }
        else
        {
            CurrentStartScreen = _vrStartScreenView;
        }
    }
}
