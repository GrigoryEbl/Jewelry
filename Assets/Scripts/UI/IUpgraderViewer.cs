using TMPro;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    internal interface IUpgraderViewer 
    {
        void OnInfoChange();
        void ChangeText(TMP_Text price, float priceInfo, TMP_Text level, int levelInfo, TMP_Text label);
        void SetImageDetail(int levelinfo, int levelToMiddleDetail, Image middleDetail, Image highDetail);
        void Slide(Slider slider, int target);
    }
}