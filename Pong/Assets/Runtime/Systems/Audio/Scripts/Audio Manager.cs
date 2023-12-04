using System;
using UnityEngine;

namespace Runtime.Systems.Audio.Scripts
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;
    
        [SerializeField] private Sound[] music, sfx;
        [SerializeField] private AudioSource musicSource, sfxSource;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void PlayMusic(string name)
        {
            var sound = Array.Find(music, item => item.name == name);

            if (sound == null)
            {
                Debug.Log("[MUSIC] Sound not found!");
                return;
            }

            musicSource.clip = sound.clip;
            musicSource.Play();
        }
    
        public void PlaySfx(string name)
        {
            var sound = Array.Find(sfx, item => item.name == name);

            if (sound == null)
            {
                Debug.Log("[SFX] Sound not found!");
                return;
            }

            sfxSource.PlayOneShot(sound.clip);
        }

        public void Toogle()
        {
            musicSource.mute = !musicSource.mute;
            sfxSource.mute = !sfxSource.mute;
        }

        public void SetVolumeMusic(float volume)
        {
            musicSource.volume = volume;
        }
    
        public void SetSfxMusic(float volume)
        {
            sfxSource.volume = volume;
        }
    }
}
