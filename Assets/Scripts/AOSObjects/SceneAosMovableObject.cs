using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using AosSdk.Core.PlayerModule;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine.Events;
public class SceneAosMovableObject : SceneAosObject
{
    [SerializeField] private MovebleObject _movebleObj;
    private MovebleObject _movableObject;

    [AosAction(name: "Проиграть анимацию замены")]
    public void PlayRepairAnimation()
    {
        if(_movebleObj==null)
        {
            _movableObject = GetComponent<MovebleObject>();
            _movableObject.RepairObject();
        }
        else if(_movebleObj!=null)
        {
            _movebleObj.RepairObject();
        }
    }
}
