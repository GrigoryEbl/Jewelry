using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class ResourceLevelView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _level;

        private Spawner _spawner;

        private void Start()
        {
            _spawner = GetComponentInParent<Spawner>();
            _level.text = _spawner.Item.Level.ToString();
        }
    }
} 