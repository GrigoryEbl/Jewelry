using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField] private uint _price;
    [SerializeField] private uint _level;

    public uint Price => _price;
    public uint Level => _level;
}
