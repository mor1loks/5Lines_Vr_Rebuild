using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject _descPlayer;
    [SerializeField] private GameObject _vrPlayer;
    [Space]
    [SerializeField] private CameraFlash _cameraFlash;
<<<<<<< Updated upstream
    [Space]
    [SerializeField] private ModeController _modeController;
    [SerializeField] private Transform _menuPosition;
    [SerializeField] private GameObject[] _menuButtons;
    [SerializeField] private GameObject _mainMenu;
=======
    [SerializeField] private CursorManager _cursorManager;
    [SerializeField] private GameObject _interacthelpers;
    [SerializeField] private DesktopCanvasHolder _desktopCanvasHolder;

>>>>>>> Stashed changes
    [SerializeField] private API _api;
    private bool _canTeleport = true;

    private Vector3 _currentPlayerPosition = new Vector3();

    public void TeleportToMainMenuLocation()
    {
        if(_canTeleport)
        {
            _api.MenuTeleport = false;
            _currentPlayerPosition = new Vector3(_modeController.GetPlayerTransform().position.x, 0.1500001f, _modeController.GetPlayerTransform().position.z);
            Player.Instance.TeleportTo(_menuPosition);
            _descPlayer.transform.rotation = _menuPosition.rotation;
            _vrPlayer.transform.rotation = _menuPosition.rotation;
            _cameraFlash.CameraFlashStart();
<<<<<<< Updated upstream
=======
            _cursorManager.EnableCursor(true);
            _mainMenu.SetActive(true);
            _menu.SetActive(true);
            _interacthelpers.SetActive(false);
            _desktopCanvasHolder.DisableAllCanvases();
            _desktopCanvasHolder.EnableCanvasByState(CanvasState.MainMenu);
            _desktopCanvasHolder.EnableCanvasByState(CanvasState.Menu);
>>>>>>> Stashed changes
        }
  
    }
    public void TeleportToPreviousLocation()
    {
        if (_canTeleport)
        {
            _api.MenuTeleport = true;
            _cameraFlash.CameraFlashStart();
            Player.Instance.TeleportTo(_currentPlayerPosition);
            foreach (var item in _menuButtons)
            {
                item.SetActive(false);
            }
            _mainMenu.SetActive(true);
        }
    }
    public void TeleporterTimeResult()
    {
        _api.MenuTeleport = false;
        _currentPlayerPosition = new Vector3(_modeController.GetPlayerTransform().position.x, 0.1500001f, _modeController.GetPlayerTransform().position.z);
        Player.Instance.TeleportTo(_menuPosition);
        _descPlayer.transform.rotation = _menuPosition.rotation;
        _vrPlayer.transform.rotation = _menuPosition.rotation;
        _cameraFlash.CameraFlashStart();

    }
    public void AllowTeleport(bool value)
    {
        _canTeleport = value;
    }
}
