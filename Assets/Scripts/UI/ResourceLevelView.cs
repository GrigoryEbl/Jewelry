using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceLevelView : MonoBehaviour
{
    [SerializeField] private TMP_Text _level;

    private Spawner _spawner;

    private void Start()
    {
        _spawner = GetComponentInParent<Spawner>();
        _level.text = _spawner.Resource.Level.ToString();
    }
}
