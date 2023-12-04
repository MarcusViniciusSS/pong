using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Systems.Audio.Scripts
{
    public class AudioUIController : MonoBehaviour
    {
        public Slider musicSlider, sfxSlider;

        private void Start()
        {
            AudioManager.Instance.PlayMusic("piano");
            AudioManager.Instance.PlaySfx("sword");
        }

        public void ToogleSound()
        {
            AudioManager.Instance.Toogle();
        }

        public void SetVolumeMusic()
        {
            AudioManager.Instance.SetVolumeMusic(musicSlider.value);
        }
        
        public void SetVolumeSfx()
        {
            AudioManager.Instance.SetSfxMusic(sfxSlider.value);
        }
    }
}
