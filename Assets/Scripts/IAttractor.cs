using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttractor
{
    void Attract(Vector3 direction, Rigidbody rigidbody, float force);
}
