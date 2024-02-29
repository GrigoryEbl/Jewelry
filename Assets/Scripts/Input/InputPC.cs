using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

[RequireComponent(typeof(Movement))]
public class InputPC : MonoBehaviour
{
    private Movement _movement;

    private void Awake()
    {
        _movement = GetComponent<Movement>();
    }

    private void Update()
    {
        Vector3 rawDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _movement.Move(rawDirection);
    }

    public void SetWorkInput(bool isActive)
    {
        print(this.name + isActive);

        if (isActive)
            return;
        else
            this.enabled = false;
    }
}
