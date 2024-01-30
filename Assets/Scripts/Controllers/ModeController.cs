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
    [Space]
    [SerializeField] private BaseMenuScreen _deskMenuScreen;
    [SerializeField] private BaseMenuScreen _vrMenuScreen;
    [Space]
    [SerializeField] private BaseInteractScreen _desktopInteractScreen;
    [SerializeField] private BaseInteractScreen _vrInteractScreen;
    [Space]
    [SerializeField] private BaseActionObject _desktopRadioActionObject;
    [SerializeField] private BaseActionObject _vrRadioActionObject;
    [Space]
    [SerializeField] private BaseActionObject _desktopSchemeActionObject;
    [SerializeField] private BaseActionObject _vrSchemeActionObject;
    [Space]
    [SerializeField] private BaseMenuController _desktopMenuController;
    [SerializeField] private BaseMenuController _vrMenuController;
    [Space]
    [SerializeField] private BaseReactionButtonsHandler _desktopReactionButtonsHandler;
    [SerializeField] private BaseReactionButtonsHandler _vrReactionButtonsHandler;
    [Space]
    [SerializeField] private EscButton _escButton;

    public BaseStartScreenView CurrentStartScreen { get; private set; }
    public BaseInteractScreen CurrentInteractScreen { get; private set; }
    public BaseMenuScreen CurrentMenuScreen { get; private set; }
    public BaseActionObject CurrentRadioObject { get; private set; }
    public BaseActionObject CurrentSchemeObject { get; private set; }
    public BaseMenuController CurrentMenuController { get; private set; }
    public BaseReactionButtonsHandler BaseReactionButtonsHandler { get; private set; }

    private LaunchMode _currentMode;
    public bool DesktopMode => _currentMode == LaunchMode.Desktop;
    private void Start()
    {
        _currentMode = _aosSettings.launchMode;
        EnableObjectsByMode();
        _escButton.EscButtonEvent += OnEscButtonAction;
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
        if (DesktopMode)
        {
            CurrentStartScreen = _desktopStartScreenView;
            CurrentInteractScreen = _desktopInteractScreen;
            CurrentMenuScreen = _deskMenuScreen;
            CurrentRadioObject = _desktopRadioActionObject;
            CurrentSchemeObject = _desktopSchemeActionObject;
            CurrentMenuController = _desktopMenuController;
            BaseReactionButtonsHandler = _desktopReactionButtonsHandler;
        }
        else
        {
            CurrentStartScreen = _vrStartScreenView;
            CurrentInteractScreen = _vrInteractScreen;
            CurrentMenuScreen = _vrMenuScreen;
            CurrentRadioObject = _vrRadioActionObject;
            CurrentSchemeObject = _vrSchemeActionObject;
            CurrentMenuController = _vrMenuController;
            BaseReactionButtonsHandler = _vrReactionButtonsHandler;
        }
    }
    private void OnEscButtonAction()
    {
        if (CurrentMenuController.InMenu)
            CurrentMenuController.TeleportToGame();
        else
            CurrentMenuController.TeleportToMenu();
    }
}
