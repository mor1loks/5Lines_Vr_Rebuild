using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PointerDevice : MonoBehaviour
{
    [SerializeField] private float minValue;
    [SerializeField] private float maxValue;
    [Space][SerializeField] private float divisionValue;
    [SerializeField] private Transform arrowTransform;
    [SerializeField] private ArrowRotationAxis arrowRotationAxis;


    private enum ArrowRotationAxis
    {
        X,
        Y,
        Z
    }

    public string SetValue(float value)
    {
        var targetRotation = arrowRotationAxis switch
        {
            ArrowRotationAxis.X => Vector3.right,
            ArrowRotationAxis.Y => Vector3.up,
            ArrowRotationAxis.Z => Vector3.forward,
            _ => throw new ArgumentOutOfRangeException()
        };

        string retVal = "HIGH";
        // value = Mathf.Clamp(value, minValue, maxValue);
        if (value < 0)
        {
            if (value > -1 * maxValue)
                targetRotation *= divisionValue * -0.01f;
            else
                targetRotation *= divisionValue * -0.015f;
            retVal = "NEGOVERBOUND";
        }
        else if (value > maxValue)
        {
            if (value >= 2 * maxValue)
                targetRotation *= divisionValue * maxValue * 0.80f;
            else
                targetRotation *= divisionValue * maxValue * 0.78f;
            retVal = "POSOVERBOUND";
        }
        else
            targetRotation *= divisionValue * value *0.76f;

        targetRotation += new Vector3(-90, 0, -41);
        Debug.Log(targetRotation + "Rotation     " + value + " value        " + divisionValue + " Division");

        arrowTransform.localRotation = Quaternion.Euler(targetRotation);
        return retVal;
    }
    public void SetMinValue(float min)
    {
        minValue = min;
    }
    public void SetMaxValue(float max)
    {
        maxValue = max;
        SetDivisionValue();
    }
    private void SetDivisionValue()
    {
        divisionValue = 108 / maxValue;
    }
    public float GetMaxValue()
    {
        return maxValue;
    }
}
