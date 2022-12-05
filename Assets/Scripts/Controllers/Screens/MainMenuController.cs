using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AosSdk.Core.PlayerModule;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject _descPlayer;
    [SerializeField] private GameObject _vrPlayer;
    [Space]
    [SerializeField] private CameraFlash _cameraFlash;
    [Space]
    [SerializeField] private ModeController _modeController;
    [SerializeField] private Transform _menuPosition;
    [SerializeField] private GameObject[] _menuButtons;
    [SerializeField] private GameObject _mainMenu;
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
    public void AllowTeleport(bool value)
    {
        _canTeleport = value;
    }
}
