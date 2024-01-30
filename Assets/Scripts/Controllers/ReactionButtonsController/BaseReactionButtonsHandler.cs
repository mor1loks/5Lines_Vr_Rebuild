using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ButtonActionName
{
    Hand,
    Hand_1,
    Hand_2,
    Hand_3,
    Hand_4,
    Eye,
    Tool,
    Tool_1,
    Pen,
    Pen_1
}

public abstract class BaseReactionButtonsHandler : MonoBehaviour
{
    public abstract void ShowReactionButtonByName(string buttonActionName, string buttonText);
    protected StringParser StringParser;
    protected Transform ButtonsSpawnPos;
    protected virtual void Start()
    {
        StringParser = new StringParser();
    }
    public void SetButtonSpawnPos(Transform newPos)
    {
        ButtonsSpawnPos = newPos;
    }
    public void SetButtonSpawnPos(Vector3 newPos)
    {
        ButtonsSpawnPos.transform.position = newPos;
    }
    public abstract void HideAllReactions();

}
