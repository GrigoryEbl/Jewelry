using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Scaler : MonoBehaviour
{
    [SerializeField] private Image[] _images = new Image[3];
    [SerializeField] private Vector3 _scale;
    [SerializeField] private float _duration;
    [SerializeField] private int _repeats;
    [SerializeField] private LoopType _loopType;

    private TemporaryImprovement _temporaryImprovement;

    public void Start()
    {
        _temporaryImprovement = GetComponentInParent<TemporaryImprovement>();

        for (int i = 0; i < _temporaryImprovement.Details.Length; i++)
        {
            if (_images[i].name == _temporaryImprovement.NameUpgradeDetail)
            {
                _images[i].gameObject.SetActive(true);
                PlayAnim(_images[i]);
                return;
            }
        }
    }

    private void PlayAnim(Image image)
    {
        image.rectTransform.DOScale(_scale, _duration).SetLoops(_repeats, _loopType).SetEase(Ease.Linear);
    }
}
