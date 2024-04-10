using UnityEngine;

public class PauseEnabler : MonoBehaviour
{
    public void Pause()
    {
        AudioListener.pause = true;
        Time.timeScale = 0;
    }

    public void Play()
    {
        AudioListener.pause = false;
        Time.timeScale = 1;
    }
}
