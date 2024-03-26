using UnityEngine;
using UnityEngine.UI;

public class TimerView : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Timer _timer;
    [SerializeField] private Image[] _imagesDetails;
    [SerializeField] private TemporaryImprovement _temporaryImprovement;

    private void OnEnable() => _temporaryImprovement.Improvement += SetImage;

    private void OnDisable() => _temporaryImprovement.Improvement -= SetImage;

    private void Update()
    {
        _image.fillAmount = _timer.Time / _timer.StartTime;
    }

    private void SetImage()
    {
        for (int i = 0; i < _temporaryImprovement.Details.Length; i++)
        {
            if (_imagesDetails[i].name == _temporaryImprovement.NameUpgradeDetail)
            {
                _imagesDetails[i].gameObject.SetActive(true);
            }
        }
    }
}
