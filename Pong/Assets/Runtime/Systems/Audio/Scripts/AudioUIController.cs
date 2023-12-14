using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Systems.Audio.Scripts
{
    public class AudioUIController : MonoBehaviour
    {
        [Header("Sliders")]
        public Slider musicSlider, sfxSlider;
        
        [Header("Toggle")]
        public Toggle toggle;

        [Header("Icons")] 
        public Sprite MusicOn, MusicOff, SoundOn, SoundOff;
        public GameObject Music, Sfx;

        [Header("Texture")] 
        public Texture ToggleOn, ToogleOff;

        private void Start()
        {
            Music.GetComponent<Image>().sprite = musicSlider.value > 0 ? MusicOn : MusicOff;
            Sfx.GetComponent<Image>().sprite = musicSlider.value > 0 ? SoundOn : SoundOff;
            
            AudioManager.Instance.PlayMusic("piano");
            AudioManager.Instance.PlaySfx("sword"); 
        }

        public void ToogleSound()
        {
            AudioManager.Instance.Toogle();

            toggle.transform.Find("Image").gameObject.GetComponent<RawImage>().texture = toggle.isOn ? ToggleOn : ToogleOff;
        }

        public void SetVolumeMusic()
        {
            AudioManager.Instance.SetVolumeMusic(musicSlider.value);
            
            Music.GetComponent<Image>().sprite = musicSlider.value > 0 ? MusicOn : MusicOff;
        }
        
        public void SetVolumeSfx()
        {
            AudioManager.Instance.SetSfxMusic(sfxSlider.value);
            Sfx.GetComponent<Image>().sprite = sfxSlider.value > 0 ? SoundOn : SoundOff;
        }

        public void ClosePainel()
        {
            gameObject.SetActive(false);
        }
    }
}
