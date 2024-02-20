using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObjectWhisAnimation : ObjectWithAnimation
{
    [SerializeField] private GameObject _gameObject;
    public override void PlayScriptableAnimationClose()
    {
       _gameObject.SetActive(true);
    }

    public override void PlayScriptableAnimationOpen()
    {
        _gameObject.SetActive(false);
    }
}
