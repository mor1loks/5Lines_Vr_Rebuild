using AosSdk.Core.PlayerModule;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using UnityEngine.UI;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Image _knob;
    private DesktopPointer _pointer;
    private void Awake()
    {
        _pointer = _knob.GetComponent<DesktopPointer>();
    }
    public void EnableCursor(bool value)
    {
        if (!value)
            Cursor.lockState = CursorLockMode.Locked;
        else
            Cursor.lockState = CursorLockMode.Confined;

        Cursor.visible = value;
        Player.Instance.CanMove = !value;
        _knob.enabled = !value;
        _pointer.enabled = !value;
    }
}
