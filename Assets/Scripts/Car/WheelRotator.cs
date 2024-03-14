using DG.Tweening;
using UnityEngine;

public class WheelRotator : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private int _repeats;
    [SerializeField] private LoopType _loopType;
    [SerializeField] private Movement _movement;
    [SerializeField] private Transform[] _wheels;

    private void Update()
    {
        if (_movement.IsMoving)
            Rotate();
    }

    public void Rotate()
    {
        foreach (var wheel in _wheels)
        {
           wheel.transform.DORotate(new Vector3(360, 0, 0), _duration, RotateMode.FastBeyond360).SetLoops(_repeats, _loopType).SetEase(Ease.Linear);
        }
    }
}