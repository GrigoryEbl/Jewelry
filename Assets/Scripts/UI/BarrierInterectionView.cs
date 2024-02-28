using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BarrierInterectionView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private GameObject _barrierInterectionScreen;
    [SerializeField] private Player _player;

    private void OnEnable() => _player.BarrierInterectionReach += OnBarrierInterectionReach;

    private void OnDisable() => _player.BarrierInterectionReach -= OnBarrierInterectionReach;

    private void OnBarrierInterectionReach(bool isActive, BarrierInterection barrierInterection)
    {
        ShowInfo(isActive, barrierInterection);
    }
    
    private void ShowInfo(bool isActive, BarrierInterection barrierInterection)
    {
        _barrierInterectionScreen.SetActive(isActive);
        _text.text = "$" + barrierInterection.Price;
    }
}
