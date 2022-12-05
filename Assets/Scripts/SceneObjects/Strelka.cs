using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Strelka : MonoBehaviour
{
    [SerializeField] private StrelkaAOS _strelkaAOS;
    private bool _condition;
    public void SetCondition(bool value)
    {
        if(_condition && !value)
        {
            _strelkaAOS.StrelkaFromPlusTominus();
        }
        else if(!_condition && value)
        {
            _strelkaAOS.StrelkaFromMinusToPlus();
        }
        _condition = value;
    }
    public bool GetCondition()
    {
        return _condition;
    }

}

