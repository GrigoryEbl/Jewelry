using UnityEngine;

public class PauseEnabler : MonoBehaviour
{
   public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Play()
    {
        Time.timeScale = 1;
    }
}
