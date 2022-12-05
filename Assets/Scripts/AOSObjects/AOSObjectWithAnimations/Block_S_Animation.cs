using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_S_Animation : SceneAosObject
{
    [SerializeField] private Animator _pkAnim;
    [SerializeField] private Animator _mkAnim;
    [AosAction(name: "Анимация AB")]
    public void PlayPKOn()
    {
        _pkAnim.SetTrigger("On");
    }
    public void PlayPKOff()
    {
        _pkAnim.SetTrigger("Off");
    }
    public void PlayMKOn()
    {
        _mkAnim.SetTrigger("On");
    }
    public void PlayMKOff()
    {
        _mkAnim.SetTrigger("Off");
    }

}
