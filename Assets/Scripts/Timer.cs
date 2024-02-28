using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private float _time;

   private void Update()
    {
        _text.text = Time.time.ToString("F2") ;
    }
}
