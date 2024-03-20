using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    [SerializeField] protected AudioClip[] sounds;

    protected AudioSource AudioSource => GetComponent<AudioSource>();

    protected void PlaySound(AudioClip audioClip, float volume = 0.8f, bool isDestroyed = false, float pitch = 1)
    {
        AudioSource.pitch = pitch;

        if (isDestroyed)
        {
            AudioSource.PlayClipAtPoint(audioClip, transform.position, volume);
        }
        else
        {
            AudioSource.PlayOneShot(audioClip, volume);
        }
    }
}
