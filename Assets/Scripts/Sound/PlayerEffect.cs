using UnityEngine;

public class PlayerEffect : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    public void Play()
    {
        _audioSource.Play();
    }

    public void DeferredPlay()
    {
        AudioSource.PlayClipAtPoint(_audioSource.clip, transform.position);
    }
}
