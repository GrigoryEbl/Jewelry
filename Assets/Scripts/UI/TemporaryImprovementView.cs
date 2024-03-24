using DG.Tweening;
using UnityEngine;

public class TemporaryImprovementView : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private Vector3 _scale;
    [SerializeField] private float _duration;
    [SerializeField] private int _repeats;
    [SerializeField] private LoopType _loopType;

    private TemporaryImprovement _temporaryImprovement;

    private void Awake()
    {
        _temporaryImprovement = GetComponentInParent<TemporaryImprovement>();
    }

    private void OnEnable()
    {
        _temporaryImprovement.ReachObject += SetActivePanel;
    }

    private void OnDisable()
    {
        _temporaryImprovement.ReachObject -= SetActivePanel;
    }

    private void SetActivePanel(bool isActive)
    {
        _panel.SetActive(isActive);
        print("reach: " + isActive);
    }
}
