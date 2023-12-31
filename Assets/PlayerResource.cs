using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class PlayerResource : MonoBehaviour
{
    [SerializeField] private float value = 0;
    [SerializeField] private float maxValue = 9999;
    public string resourceName = "money";

    public static PlayerResource Find (string name)
    {
        foreach (var resource in FindObjectsOfType<PlayerResource>())
        {
            if (resource.resourceName == name)
            {
                return resource;
            }
        }
        return null;
    }
    public float GetValue() => value;
    public float GetMaxValue() => maxValue;

    public void ChangeValue(float change)
    {
        value = Mathf.Clamp(value + change, 0, maxValue);
        if (ValueChangeEvent != null)
        {
            ValueChangeEvent(value);
        }
        if (value == 0)
        {
            OnZero.Invoke();
        }
    }
    public event Action<float> ValueChangeEvent;
    public UnityEvent OnZero;
}