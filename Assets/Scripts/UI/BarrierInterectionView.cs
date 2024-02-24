using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BarrierInterectionView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private GameObject _barrierInterectionScreen;
    [SerializeField] Player _player;
    [SerializeField] Button _button;

    private void Start()
    {
        _button = GetComponentInChildren<Button>();
    }

    private void Update()
    {
        
    }

    private void OnEnable() => _player.BarrierInterectionReach += OnBarrierInterectionReach;

    private void OnDisable() => _player.BarrierInterectionReach -= OnBarrierInterectionReach;

    public void OnBarrierInterectionReach(bool isActive, BarrierInterection barrierInterection)
    {
        ShowInfo(isActive, barrierInterection);
    }
    
    public void ShowInfo(bool isActive, BarrierInterection barrierInterection)
    {
        _barrierInterectionScreen.SetActive(isActive);
        _text.text = "$" + barrierInterection.Price;
    }
}
