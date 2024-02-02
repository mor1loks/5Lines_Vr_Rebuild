using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ampermetr : MonoBehaviour
{
    [SerializeField] private GameObject _ampermetr;
    private Transform _amperPos;
    public bool Active { get; private set; }
    private void Update()
    {
        transform.position = _amperPos.position;
        transform.rotation = _amperPos.rotation;
    }
    public void EnableAmper(bool value)
    {
        if (value)
        {
    
            _ampermetr.SetActive(value);
        }
        else
            _ampermetr.SetActive(false);
        Active = _ampermetr.activeSelf;
    }
    public void SetAmperPos(Transform newPos) => _amperPos = newPos;
 }
