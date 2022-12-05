using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;

public class ScenaAosObjectWithAnimation : SceneAosObject
{
    private IAnimationObject _animationObject;

    [AosAction(name: "Проиграть анимацию открытия")]
    public void PlayOpenAnimation()
    {
        _animationObject = GetComponent<IAnimationObject>();
        if(_animationObject!=null)
        _animationObject.OpenAnimation();
    }

    [AosAction(name: "Проиграть анимацию закрытия")]
    public void PlayCloseAnimation()
    {
        _animationObject = GetComponent<IAnimationObject>();
        if (_animationObject != null)
            _animationObject.CloseAnimation();
    }

}
