using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float fps;

    void OnGUI()
    {
        fps = 1.0f / Time.deltaTime;
        GUILayout.Label("FPS: " + (int)fps);
        GUILayout.Label("Play time: " + Time.time.ToString("F2"));
    }
}
