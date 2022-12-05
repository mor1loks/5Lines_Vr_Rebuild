using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;
[AosSdk.Core.Utils.AosObject(name: "AosMeasureButton")]
public class MeasureAosButton : AosObjectBase
{
    [AosAction("Вкл. Выкл. объекта")]
    public void ActivateMeasureButton([AosParameter("Включение кнопки")] bool active)
    {
        Collider col = gameObject.GetComponent<Collider>();
        if (col != null)
            col.enabled = active;
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if(spriteRenderer !=null)
            spriteRenderer.enabled = active;
    }

}
