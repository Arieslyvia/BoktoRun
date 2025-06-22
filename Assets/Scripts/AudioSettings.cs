using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    public Slider musicSlider;
    public Sprite soundOn;
    public Sprite muteSound;
    public GameObject musicIcon;

    public Slider sfxSlider;
    public Sprite sfxOn;
    public Sprite sfxMute;
    public GameObject sfxIcon;
    

    public void VolumeChange()
    {

        if (AudioManager.instance.backgroundSound.volume <= 0.09f)
        {

            musicIcon.GetComponent<Image>().sprite = muteSound;
        }
        else
        {

            musicIcon.GetComponent<Image>().sprite = soundOn;
        }
        AudioManager.instance.backgroundSound.volume = musicSlider.value;
    }

    public void SfxChange()
    {
        if (AudioManager.instance.eventSound.volume <= 0.09f)
        {

            sfxIcon.GetComponent<Image>().sprite = sfxMute;
        }
        else
        {

            sfxIcon.GetComponent<Image>().sprite = sfxOn;
        }
        AudioManager.instance.eventSound.volume = sfxSlider.value;
    }

}
