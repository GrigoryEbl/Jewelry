using UnityEngine;

namespace Item
{
    public class CollectedItem : MonoBehaviour
    {
        [SerializeField] private uint _price;
        [SerializeField] private uint _level;

        public uint Price => _price;
        public uint Level => _level;
    }
}