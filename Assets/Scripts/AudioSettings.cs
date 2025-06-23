using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    public GameObject vibrationIcon;
  
    public Sprite vibrationOn;
    public Sprite vibrationOff;
    public bool isVibrate;

    public static float musicState;
    public static int vibrateState;
    public static float sfxState;

    public static float bgVolumeValue;
    public static float eventVolumeValue;


    private void Start()
    {
        //musicSlider.value = bgVolumeValue;
       // sfxSlider.value = eventVolumeValue;

        if (musicState >= 0.09f)
        {
            musicIcon.GetComponent<Image>().sprite = muteSound;
        }
        else
        {
            musicIcon.GetComponent <Image>().sprite = soundOn;
        }
        if(vibrateState == 0)
        {
          vibrationIcon.GetComponent<Image>().sprite = vibrationOn;

        }
        else
        {
            vibrationIcon.GetComponent <Image>().sprite = vibrationOff;
        }

        if(sfxState == 0.09f)
        {
            sfxIcon.GetComponent<Image>().sprite = sfxMute;
        }
        else
        {
            sfxIcon.GetComponent <Image>().sprite = sfxOn;
        }
    }

    public void VolumeChange()
    {

        if (AudioManager.instance.backgroundSound.volume <= 0.09f)
        {

            musicIcon.GetComponent<Image>().sprite = muteSound;
            bgVolumeValue = musicSlider.value;
        }
        else
        {

            musicIcon.GetComponent<Image>().sprite = soundOn;
            bgVolumeValue = musicSlider.value;
        }
        AudioManager.instance.backgroundSound.volume = musicSlider.value;
    }

    public void SfxChange()
    {
        if (AudioManager.instance.eventSound.volume <= 0.09f)
        {

            sfxIcon.GetComponent<Image>().sprite = sfxMute;
            eventVolumeValue = sfxSlider.value;
        }
        else
        {

            sfxIcon.GetComponent<Image>().sprite = sfxOn;
            eventVolumeValue = sfxSlider.value;
        }
        AudioManager.instance.eventSound.volume = sfxSlider.value;
    }

    public void OkayIcon()
    {
        AudioManager.instance.ButtonSound();
        vibrationIcon.GetComponent<Image>().sprite = vibrationOn;
    }

    public void CancelIcon()
    {
        AudioManager.instance.ButtonSound();
        vibrationIcon.GetComponent <Image>().sprite = vibrationOff;
    }
   
}
