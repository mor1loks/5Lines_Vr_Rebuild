using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AosSdk.Core.Utils.AosObject(name: "Анимация Amper")]

public class AmperAnim : AosObjectBase
{
    private Animator _anim;
    private void Start()
    {
        _anim = GetComponent<Animator>();
    }
    [AosAction(name: "Проиграть анимацию Нет Перевода")]
    public void NoPerev()
    {
        _anim.SetTrigger("NoPerev");
    }
    [AosAction(name: "Проиграть анимацию Номального перевода")]
    public void NormPerev()
    {
        _anim.SetTrigger("NormPerev");
    }
    [AosAction(name: "Проиграть анимацию Фрикции")]
    public void FrictPerev()
    {
        _anim.SetTrigger("FrictPerev");
    }
    [AosAction(name: "Проиграть анимацию Камня")]
    public void StonePerev()
    {
        _anim.SetTrigger("StonePerev");
    }
}
