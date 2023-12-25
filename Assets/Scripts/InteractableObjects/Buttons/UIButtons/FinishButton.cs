using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishButton : BaseUIButton
{
    private const string FINISH = "finish";
    protected override void Click()
    {
   API.OnInvokeNavAction(FINISH);
    }
}
