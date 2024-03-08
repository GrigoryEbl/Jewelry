using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BarrierInterectionView : MonoBehaviour
{
    [SerializeField] private BarrierInterection _barrierInterection;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private GameObject _barrierInterectionScreen;

    private void OnEnable()
    {
        _barrierInterection.BarrierReach += ShowInfo;
        _barrierInterectionScreen.SetActive(false);
    }

    private void OnDisable()
    {
        _barrierInterection.BarrierReach -= ShowInfo;
    }

    private void ShowInfo(bool isActive)
    {
        _barrierInterectionScreen.SetActive(isActive);
        _text.text = "$" + _barrierInterection.Price;
    }
}
