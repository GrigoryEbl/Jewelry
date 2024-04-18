using UnityEngine;

namespace Assets.Scripts.Car.Details
{
    internal interface IImprovable
    {
        int Level { get; }

        public void Upgrade();
    }
}