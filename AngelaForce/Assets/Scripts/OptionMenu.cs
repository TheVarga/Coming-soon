using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class OptionMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    Resolution[] resolutions;
    private void Start()
    {
        resolutions = Screen.resolutions;
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetVideoQuality(int qualityIndex) {
        QualitySettings.SetQualityLevel(qualityIndex);    
    }
    public void SetFullscreen(bool isFullscreen) {
        Screen.fullScreen = isFullscreen;
    }
}
