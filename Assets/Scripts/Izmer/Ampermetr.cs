using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ampermetr : MonoBehaviour
{
    [SerializeField] private GameObject _ampermetr;
    private Transform _amperPos;
    private void Start()
    {
        _amperPos = GetComponent<Transform>();
    }
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
    }
    public void SetAmperPos(Transform newPos) => _amperPos = newPos;
 }
