using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BarrierInterectionView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private GameObject _barrierInterectionScreen;
    [SerializeField] private BarrierInterection _barrierInterection;

    private void Update()
    {
        _text.text = "$" + _barrierInterection.Price;
    }

    public void ShowScreen(bool isActive)
    {
        _barrierInterectionScreen.SetActive(isActive);
    }
}
