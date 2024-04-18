using UnityEngine;

namespace Assets.Scripts.Sounds
{
    public class PlayerEffect : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private float _volume = 0.65f;

        public void Play()
        {
            _audioSource.PlayOneShot(_audioSource.clip, _volume);
        }

        public void DeferredPlay()
        {
            AudioSource.PlayClipAtPoint(_audioSource.clip, transform.position);
        }
    }
}