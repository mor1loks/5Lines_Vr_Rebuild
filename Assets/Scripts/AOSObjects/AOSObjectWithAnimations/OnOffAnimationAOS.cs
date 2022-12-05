using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using Newtonsoft.Json.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking.Types;

public class OnOffAnimationAOS : SceneAosObject
{ 
    private Animator _anim;

    [AosAction(name: "Анимация включения")]
    public void PlayOffOn()
    {
        _anim = GetComponent<Animator>();
        _anim.SetTrigger("standart");
    }
    [AosAction(name: "Анимация выключения")]
    public void PlayOnOff()
    {
        _anim = GetComponent<Animator>();
        _anim.SetTrigger("inverse");
    }
}
