using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using YG;

[RequireComponent(typeof(Movement))]
public class InputPC : MonoBehaviour
{
    private Movement _movement;

    public bool Moving => Input.anyKey;

    private void Awake()
    {
        if (YandexGame.EnvironmentData.isMobile)
            this.enabled = false;

        _movement = GetComponent<Movement>();
    }

    private void Update()
    {
        if (Moving == false)
        {
            _movement.Stop();
            return;
        }

        Vector3 rawDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        _movement.Move(rawDirection);
    }
}
