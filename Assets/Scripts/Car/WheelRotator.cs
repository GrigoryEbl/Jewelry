using DG.Tweening;
using System.IO;
using UnityEngine;

public class WheelRotator : MonoBehaviour
{
    [SerializeField] private Transform[] _wheelsModels;

    [SerializeField] private Movement _movement;

    private void Update()
    {
        if (_movement.IsMoving)
        {
            foreach (Transform wheel in _wheelsModels)
            {
                wheel.transform.Rotate(new Vector3(1, 0, 0) * _movement.Speed);
            }
        }
    }
}