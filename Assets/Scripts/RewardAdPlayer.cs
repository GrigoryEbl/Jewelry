using UnityEngine;
using YG;

public class RewardAdPlayer : MonoBehaviour
{
    private YandexGame _yandexGame;

    private void Awake()
    {
        _yandexGame = FindObjectOfType<YandexGame>();
    }

    public void ShowAd()
    {
        _yandexGame._RewardedShow(0);
    }
}
