using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
[AosSdk.Core.Utils.AosObject(name: "Анимация Sp6")]
public class Sp6AnimationController : AosObjectBase
{
    [SerializeField] private LocationController _locationController;
    private Animator _anim;
    private void Start()
    {
        _anim = GetComponent<Animator>();
    }
    [AosAction(name: "Проиграть анимацию Отказ шибер минус")]
    public void PlayShiberMinusAnim()
    {
        _anim.SetTrigger("otkazShiberMinus");
    }
    [AosAction(name: "Проиграть анимацию Отказ шибер плюс")]
    public void PlayShiberPlusAnim()
    {
        _anim.SetTrigger("otkazShiberPlus");
    }
    [AosAction(name: "Проиграть анимацию СВ Тяги минус")]
    public void PlaySvTyagMinusAnim()
    {
        _anim.SetTrigger("otkazSvTyagMinus");
    }
    [AosAction(name: "Проиграть анимацию СВ Тяги плюс")]
    public void PlaySvTyagPlusAnim()
    {
        _anim.SetTrigger("otkazSvTyagPlus");
    }
    [AosAction(name: "Проиграть анимацию Серьги дальней минус")]
    public void PlaySergaDalMinusAnim()
    {
        _anim.SetTrigger("otkazSergaDalSvTyagMinus");
    }
    [AosAction(name: "Проиграть анимацию Серьги дальней плюс")]
    public void PlaySergaDalPlusAnim()
    {
        _anim.SetTrigger("otkazSergaDalSvTyagPlus");
    }
    [AosAction(name: "Проиграть анимацию Серьги ближней плюс")]
    public void PlaySergaBlizkPlusAnim()
    {
        _anim.SetTrigger("otkazSergaBlizkSvTyagPlus");
    }
    [AosAction(name: "Проиграть анимацию Серьги ближней минус")]
    public void PlaySergaBlizkMinusAnim()
    {
        _anim.SetTrigger("otkazSergaBlizkSvTyagMinus");
    }
    [AosAction(name: "Проиграть анимацию Длинной тяги плюс")]
    public void PlayDlinTyagPlusAnim()
    {
        _anim.SetTrigger("otkazDlinTyagPlus");
    }
    [AosAction(name: "Проиграть анимацию Длинной тяги минус")]
    public void PlayDlinTyagMinusAnim()
    {
        _anim.SetTrigger("otkazDlinTyagMinus");
    }
    [AosAction(name: "Проиграть анимацию Короткой тяги минус")]
    public void PlayKorotkTyagMinusAnim()
    {
        _anim.SetTrigger("otkazKorotkTyagMinus");
    }
    [AosAction(name: "Проиграть анимацию Короткой тяги плюс")]
    public void PlayKorotkTyagPlusAnim()
    {
        _anim.SetTrigger("otkazKorotkTyagPlus");
    }
    [AosAction(name: "Проиграть анимацию Линейка 01 минус")]
    public void PlayLin01MinusAnim()
    {
        _anim.SetTrigger("otkazLin01Minus");
    }
    [AosAction(name: "Проиграть анимацию Линейка 01 плюс")]
    public void PlayLin01PlusAnim()
    {
        _anim.SetTrigger("otkazLin01Plus");
    }
    [AosAction(name: "Проиграть анимацию Линейка 02 плюс")]
    public void PlayLin02PlusAnim()
    {
        _anim.SetTrigger("otkazLin02Plus");
    }
    [AosAction(name: "Проиграть анимацию Линейка 02 минус")]
    public void PlayLin02MinusAnim()
    {
        _anim.SetTrigger("otkazLin02Minus");
    }
    [AosAction(name: "Проиграть анимацию Стретка плюс трение минус")]
    public void PlayStrelPlusFrictMinusAnim()
    {
        _anim.SetTrigger("otkazStrelPlusFrictMinus");
    }
    [AosAction(name: "Проиграть анимацию Стретка минус трение плюс")]
    public void PlayStrelMinusFrictPlusAnim()
    {
        if (InSoundPlace(_locationController.GetLocationName()))
            SoundPlayer.Instance.PlayRailFriktSound();
        _anim.SetTrigger("otkazStrelMinusFrictPlus");
    }
    [AosAction(name: "Проиграть анимацию Стретка плюс двигатель минус")]
    public void PlayStrelPlusEngineMinusAnim()
    {
        _anim.SetTrigger("otkazStrelPlusEngineMinus");
    }
    [AosAction(name: "Проиграть анимацию Стретка минус двигатель плюс")]
    public void PlayStrelMinusEnginePlusAnim()
    {
        _anim.SetTrigger("otkazStrelMinusEnginePlus");
    }
    [AosAction(name: "Проиграть анимацию Камень двигатель минус")]
    public void PlayRockEngineMinusAnim()
    {
        if (InSoundPlace(_locationController.GetLocationName()))
            SoundPlayer.Instance.PlayRailStoneSound();
        _anim.SetTrigger("otkazRockEngineMinus");
      
    }
    [AosAction(name: "Проиграть анимацию Камень двигатель плюс")]
    public void PlayRockEnginePlusAnim()
    {
        if (InSoundPlace(_locationController.GetLocationName()))
            SoundPlayer.Instance.PlayRailNormSound();
        _anim.SetTrigger("otkazRockEnginePlus");
    }

    [AosAction(name: "Проиграть анимацию плюс")]
    public void PlayPlusAnim()
    {
        if (InSoundPlace(_locationController.GetLocationName()))
            SoundPlayer.Instance.PlayRailNormSound();
        _anim.SetTrigger("plusAnim");
    }
    [AosAction(name: "Проиграть анимацию минус")]
    public void PlayMinusAnim()
    {
        if (InSoundPlace(_locationController.GetLocationName()))
            SoundPlayer.Instance.PlayRailNormSound();
        _anim.SetTrigger("minusAnim");
    }
    private bool InSoundPlace(string placeName)
    {
        if (placeName == "field" || placeName == "clutch" || placeName == "actuator" ||
            placeName == "e_drive" || placeName == "switch" || placeName == "apron" ||
            placeName == "rod" || placeName == "hollow_left" || placeName == "hollow_right")
            return true;
        else
     return false;
    }
}
