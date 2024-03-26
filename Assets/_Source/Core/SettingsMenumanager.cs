using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

namespace _Source.Core
{
    public class SettingsMenumanager : MonoBehaviour
    {
        public TMP_Dropdown graphicsDropdown;
        public Slider masterVolume;
        public Slider musicVolume;
        public Slider sfxVolume;
        public AudioMixer mainAudioMixer;

        public void ChangeGraphicsQuality()
        {
            QualitySettings.SetQualityLevel(graphicsDropdown.value);
        }

        public void ChangeMasterVolume()
        {
            mainAudioMixer.SetFloat("MasterVolume", masterVolume.value);
        }
        
        public void ChangeMusicVolume()
        {
            mainAudioMixer.SetFloat("MusicVolume", musicVolume.value);
        }
        
        public void ChangeSfxVolume()
        {
            mainAudioMixer.SetFloat("SFXVolume", sfxVolume.value);
        }
    }
}
