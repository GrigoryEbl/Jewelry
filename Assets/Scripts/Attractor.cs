using UnityEngine;

public class Attractor : MonoBehaviour
{
    public void Attract(Transform transform, Transform target, float force)
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, force * Time.deltaTime);
    }
}