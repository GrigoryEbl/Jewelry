using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float Time { get; private set; }
    public float StartTime { get; private set; }

    public Action TimeEmpty;

    public IEnumerator Work(float startTime)
    {
        StartTime = startTime;
        Time = startTime;

        while (Time > 0)
        {
            Time -= UnityEngine.Time.deltaTime;

            yield return null;
        }

        TimeEmpty?.Invoke();
    }
}
