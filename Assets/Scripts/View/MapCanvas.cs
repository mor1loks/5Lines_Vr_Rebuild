using AosSdk.Core.PlayerModule.Pointer;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCanvas : MonoBehaviour
{
    [SerializeField] private GameObject _canvasObject;
    [SerializeField] private CursorManager _cursormanager;
    [SerializeField] private CloseCanvasButton _closeCanvasButton;
    [SerializeField] private EscButton _escButton;
    private void Start()
    {
        EnableImageButton.MapButtonClickEvent += OnMapButtonClickEvent;
        _closeCanvasButton.BackButtonClickEvent += OnCloseButtonClickEvent;
        _escButton.EscButtonClickEvent += OnEscButtonClickEvent;
    }

    private void OnMapButtonClickEvent()
    {
        SoundPlayer.Instance.PlayMapOpenSound();
        _cursormanager.EnableCursor(true);
        _canvasObject.SetActive(true);
        _closeCanvasButton.gameObject.SetActive(true);
    }

    private void OnCloseButtonClickEvent()
    {
        SoundPlayer.Instance.PlayMapCloseSound();
        _cursormanager.EnableCursor(false);
        _canvasObject.SetActive(false);
        _closeCanvasButton.gameObject.SetActive(false);
    }
    private void OnEscButtonClickEvent()
    {
        _canvasObject.SetActive(false);
        _closeCanvasButton.gameObject.SetActive(false);
    }
}
