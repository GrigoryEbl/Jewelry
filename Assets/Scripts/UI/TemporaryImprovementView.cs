using DG.Tweening;
using Assets.Scripts.TemporaryImprovement;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class TemporaryImprovementView : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;
        [SerializeField] private Vector3 _scale;
        [SerializeField] private float _duration;
        [SerializeField] private int _repeats;
        [SerializeField] private LoopType _loopType;

        private TemporaryImprovementController _temporaryImprovement;

        private void Awake()
        {
            _temporaryImprovement = GetComponentInParent<TemporaryImprovementController>();
        }

        private void OnEnable()
        {
            _temporaryImprovement.ObjectReached += SetActivePanel;
        }

        private void OnDisable()
        {
            _temporaryImprovement.ObjectReached -= SetActivePanel;
        }

        private void SetActivePanel(bool isActive)
        {
            _panel.SetActive(isActive);
            print("reach: " + isActive);
        }
    }
} 