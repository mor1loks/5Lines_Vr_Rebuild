using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
public class MouseRayCastHandler : MonoBehaviour
{
    private InteractHand _interactHand;
    private Camera _currentCamera;
    private IHoverAble _currentHoverable;
    private void Update()
    {
        if (_currentCamera == null)
            return;
        var collisionObject = CheckRaycastCollider();
        if (Input.GetMouseButtonDown(0))
        {
            if (collisionObject.collider != null)
                CheckCollisionClick(collisionObject);
        }
        if (collisionObject.collider != null)
            CheckCollisionHover(collisionObject);
    }
    private RaycastHit CheckRaycastCollider()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 100f;
        mousePos = _currentCamera.ScreenToWorldPoint(mousePos); ;
        Debug.DrawRay(_currentCamera.transform.position, mousePos - _currentCamera.transform.position, Color.blue);
        Ray ray = _currentCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            return hit;
        }

        return hit;
    }
    private void CheckCollisionClick(RaycastHit hit)
    {
        if (hit.collider.gameObject.TryGetComponent(out IClickAble obj))
        {
            obj.OnClicked(_interactHand);
            Debug.Log("Clicked");
        }
    }
    private void CheckCollisionHover(RaycastHit hit)
    {
        if (hit.collider.gameObject.TryGetComponent(out IHoverAble obj))
        {
            ResetHoverableObject();
            _currentHoverable = obj;
            _currentHoverable.OnHoverIn(_interactHand);
            Debug.Log("HOVERED");
        }
        else
        {
            ResetHoverableObject();
            return;
        }
    }
    private void ResetHoverableObject()
    {
        if (_currentHoverable != null)
        {
            _currentHoverable.OnHoverOut(_interactHand);
            _currentHoverable = null;
        }
    }
    public void SetActionCamera(Camera camera) => _currentCamera = camera;

}
