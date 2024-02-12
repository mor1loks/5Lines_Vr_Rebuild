using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using UnityEngine.Events;
using AosSdk.Core.PlayerModule;

public class MuftaAnimation : ObjectWithAnimation
{
    [SerializeField] private GameObject _roof;

    private bool _isAnimated = false;
    private bool _isOpen = false;

    private IEnumerator RoofMover(bool value)
    {
        if (!_isAnimated && value)
        {
            Player.Instance.CanMove = false;
            _isAnimated = true;
            _roof.SetActive(true);
            _isOpen = true;
            int y = 0;
            while (y < 25)
            {
                 _roof.transform.position += new Vector3(0, 0.01f, 0);
                yield return new WaitForSeconds(0.02f);
                y++;
            }
                _roof.SetActive(false);
        }
        else if (!_isAnimated && !value)
        {
            _isAnimated = true;
            _isOpen = false;
            _roof.SetActive(true);
            int y = 0;
            while (y < 25)
            {
                _roof.transform.position -= new Vector3(0, 0.01f, 0);
                yield return new WaitForSeconds(0.02f);
                y++;
            }
        }
        _isAnimated = false;
        Player.Instance.CanMove = true;
    }
    public override void PlayScriptableAnimationClose()
    {
        if (_isOpen)
            StartCoroutine(RoofMover(false));
    }

    public override void PlayScriptableAnimationOpen()
    {
        if (!_isOpen)
            StartCoroutine(RoofMover(true));
    }
}


