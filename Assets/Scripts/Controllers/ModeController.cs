using AosSdk.Core.Utils;
using UnityEngine;

public class ModeController : MonoBehaviour
{
    [SerializeField] private AosSDKSettings _aosSettings;
    [SerializeField] private GameObject _desktopPlayer;
    [SerializeField] private GameObject _vrPlayer;
    [Space]
    [SerializeField] private BaseStartScreenView _desktopStartScreenView;
    [SerializeField] private BaseStartScreenView _vrStartScreenView;
    [SerializeField] private BaseMenuScreen _deskMenuScreen;
    [SerializeField] private BaseMenuScreen _vrMenuScreen;
    [Space]
    [SerializeField] private BaseInteractScreen _desktopInteractScreen;
    [SerializeField] private BaseInteractScreen _vrInteractScreen;

    public BaseStartScreenView CurrentStartScreen { get; private set; }
    public BaseInteractScreen CurrentInteractScreen { get; private set; }
    public BaseMenuScreen CurrentMenuScreen { get; private set; }

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
            CurrentInteractScreen = _desktopInteractScreen;
            CurrentMenuScreen = _deskMenuScreen;
        }
        else
        {
            CurrentStartScreen = _vrStartScreenView;
            CurrentInteractScreen = _vrInteractScreen;
            CurrentMenuScreen = _vrMenuScreen;
        }
    }
}
