using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.PlayerModule.Pointer;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class MouseRayCastHandler : MonoBehaviour
{
    private InteractHand _interactHand;
    private Camera _currentCamera;
    private IHoverAble _currentHoverable;
    public Action<VectorHolder> MousePosHoverEvent;
    public Action<VectorHolder> MousePosClickEvent;
    private VectorHolder _mousePosHolder;
    public bool CanHover { get; set; } = true;
    private void Start()
    {
        _mousePosHolder = new VectorHolder();
    }
    private void Update()
    {
        if (_currentCamera == null || !CanHover)
        {
            MousePosHoverEvent?.Invoke(null);
            MousePosClickEvent?.Invoke(null);
            return;
        }
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
        mousePos = _currentCamera.ScreenToWorldPoint(mousePos);
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
        if (hit.collider.gameObject.GetComponent<IPointerClickHandler>() != null)
            return;
        if (hit.collider.gameObject.TryGetComponent(out IClickAble obj))
        {
            obj.OnClicked(_interactHand);
            _mousePosHolder.Position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            MousePosClickEvent?.Invoke(_mousePosHolder);
        }
        else
            MousePosClickEvent?.Invoke(null);
    }
    private void CheckCollisionHover(RaycastHit hit)
    {
        if (hit.collider.gameObject.TryGetComponent(out IHoverAble obj))
        {
            ResetHoverableObject();
            _currentHoverable = obj;
            _currentHoverable.OnHoverIn(_interactHand);
            _mousePosHolder.Position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            MousePosHoverEvent?.Invoke(_mousePosHolder);
        }
        else
        {
            ResetHoverableObject();
            MousePosHoverEvent?.Invoke(null);
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
    private bool IsUi()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
    public void SetActionCamera(Camera camera) => _currentCamera = camera;

}
