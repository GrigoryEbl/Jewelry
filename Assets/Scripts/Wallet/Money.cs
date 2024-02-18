using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    private uint _value;

    public uint Value => _value;

    public void SetValue(uint value)
    {
        _value = value;
    }
}
