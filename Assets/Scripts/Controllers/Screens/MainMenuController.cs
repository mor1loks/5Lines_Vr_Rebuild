using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _menu;
    [SerializeField] private CameraFlash _cameraFlash;
    [SerializeField] private CursorManager _cursorManager;
    [SerializeField] private GameObject _interacthelpers;
    [SerializeField] private DesktopCanvasHolder _desktopCanvasHolder;

    [SerializeField] private API _api;
    private bool _canTeleport = true;

    public void TeleportToMenu()
    {
        if(_canTeleport)
        {
            _api.OnMenuInvoke();
            _cameraFlash.CameraFlashStart();
            _cursorManager.EnableCursor(true);
            _mainMenu.SetActive(true);
            _menu.SetActive(true);
            _interacthelpers.SetActive(false);
            _desktopCanvasHolder.DisableAllCanvases();
            _desktopCanvasHolder.EnableCanvasByState(CanvasState.MainMenu);
            _desktopCanvasHolder.EnableCanvasByState(CanvasState.Menu);
        }
    }
    public void TeleportToGame()
    {
        if (_canTeleport)
        {
            _api.MenuTeleport = true;
            _cursorManager.EnableCursor(false);
            _cameraFlash.CameraFlashStart();
            _mainMenu.SetActive(false);
            _menu.SetActive(false);
            _interacthelpers.SetActive(true);
        }
    }
    public void TeleporterTimeResult()
    {
        _api.MenuTeleport = false;
        _cursorManager.EnableCursor(true);
        _mainMenu.SetActive(true);
        _menu.SetActive(true);
        _cameraFlash.CameraFlashStart();
    }
    public void AllowTeleport(bool value)
    {
        _canTeleport = value;
    }
}
