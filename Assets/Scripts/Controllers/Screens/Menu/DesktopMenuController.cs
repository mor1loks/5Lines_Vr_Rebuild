using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class DesktopMenuController : BaseMenuController
{
    [SerializeField] private CameraFlash _cameraFlash;
    [SerializeField] private CursorManager _cursorManager;

    public override void TeleportToMenu()
    {
        base.TeleportToMenu();
        _cameraFlash.CameraFlashStart();
        _cursorManager.EnableCursor(true);
    }
    public override void TeleportToGame()
    {
        base.TeleportToGame();
        _cursorManager.EnableCursor(false);
        _cameraFlash.CameraFlashStart();
    }
    public override void TeleportByGameTimer()
    {
        base.TeleportByGameTimer();
        _cursorManager.EnableCursor(true);
        _cameraFlash.CameraFlashStart();
    }
}
