using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSetting : MonoBehaviour
{
    public GameObject musicOn;
    public GameObject musicOff;
    public static float musicValue;

    public GameObject sfxOn;
    public GameObject sfxOff;
    public static float sfxValue;

    public Slider musicSlider;
    public Slider sfxSlider;

    private void Start()
    {
       /* musicSlider.value = 1;
        sfxSlider.value = 1;*/
    }

    public void musicVolChange()
    {
        AudioManager.instance.backgroundSound.volume= musicSlider.value;
        if (musicSlider.value < 0.1f)
        {
            musicOff.SetActive(true);
            musicOn.SetActive(false);
        }
        else
        {
            musicOn.SetActive(true);
            musicOff.SetActive(false);
        }
        musicValue = musicSlider.value;
    }

    public void sfxVolChange()
    {
        AudioManager.instance.eventSound.volume = sfxSlider.value;
        if (sfxSlider.value < 0.1f)
        {
            sfxOff.SetActive(true);
            sfxOn.SetActive(false);
        }
        else
        {
            sfxOn.SetActive(true);
            sfxOff.SetActive(false);
        }
        sfxValue = sfxSlider.value;
    }
}
