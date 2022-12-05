using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetCollidersActivator : MonoBehaviour
{
    [SerializeField] private TriggerObject _actuator;
    [SerializeField] private TriggerObject _switch;
    [SerializeField] private TriggerObject _field;

    public static StreetCollidersActivator Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    public void ActivateColliders(string value)
    {
        if(value=="switch")
        {
            _actuator.EnableObject(true);
            _field.EnableObject(true);
        }
        else if(value== "actuator")
        {
            _switch.EnableObject(true);
            _field.EnableObject(true);
        }
        else if(value == "field")
        {
            _switch.EnableObject(true);
            _actuator.EnableObject(true);
        }
    }
}
