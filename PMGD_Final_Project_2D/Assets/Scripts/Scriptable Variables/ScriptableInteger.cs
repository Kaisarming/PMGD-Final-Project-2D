using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Scriptable Integer", menuName = "Scriptable Variable/Integer")]

public class ScriptableInteger : ScriptableObject
{
    public int value;
    public int defaultValue;
    public bool resetOnEnable;

    // Start is called before the first frame update
    private void OnEnable()
    {
        if (resetOnEnable)
        {
            reset();
        }
    }

    internal void reset()
    {
        value = defaultValue;
    }
}
