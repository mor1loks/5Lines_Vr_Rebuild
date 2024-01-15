using AosSdk.Core.Utils;
using UnityEngine;

[AosSdk.Core.Utils.AosObject(name: "Зеленая лампочка")]
public class LampEnabler : AosObjectBase
{
    [SerializeField] private Lamp _lamp;
    [AosAction(name: "Сменить цвет лампочки: Зеленый")]
    public void SetLampColor()
    {
        _lamp.ChangeColor();
    }

    [AosAction(name: "Сменить цвет лампочки: Черный")]
    public void ResetLampColor()
    {
        _lamp.ResetColor();
    }
}
