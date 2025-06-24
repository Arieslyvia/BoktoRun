using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class AudioSetting : MonoBehaviour
{
    public GameObject musicOn;
    public GameObject musicOff;

    public static bool isQuit;

    public GameObject sfxOn;
    public GameObject sfxOff;
    
    public Slider musicSlider;
    public Slider sfxSlider;

    public Sprite vibration;
    public Sprite vibrationOff;
    public GameObject vibrationButton;
    public static int vibrationState;
    public static bool isVibrating = true;

    public Button firstMenuButton;
    public Button secondMenuButton;
    public Button thirdMenuButton;

    public Button firstGameButton;
    public Button secondGameButton;
    public Button thirdGameButton;

    public AudioClip plasticFrog;
    public AudioClip chillRabbit;
    public AudioClip moodyTrap;
    public AudioClip chasingTheHorizon;
    public AudioClip popSong;
    public AudioClip popSong2;


    private void Start()
    {
        firstMenuButton.onClick.AddListener(() => AudioManager.instance.ChangeBgClip(plasticFrog));
        secondMenuButton.onClick.AddListener(() => AudioManager.instance.ChangeBgClip(chillRabbit));
        thirdMenuButton.onClick.AddListener(() => AudioManager.instance.ChangeBgClip(moodyTrap));

        firstGameButton.onClick.AddListener(() => AudioManager.instance.ChangegameClip(chasingTheHorizon));
        secondGameButton.onClick.AddListener(() => AudioManager.instance.ChangegameClip(popSong));
        thirdGameButton.onClick.AddListener(() => AudioManager.instance.ChangegameClip(popSong2));

        if (isQuit == true)
        {
            Debug.Log(AudioManager.musicValue);
            Debug.Log(AudioManager.sfxValue);
            AudioManager.instance.backgroundSound.volume = AudioManager.musicValue;
            musicSlider.value = AudioManager.musicValue;
            AudioManager.instance.eventSound.volume = AudioManager.sfxValue;
            sfxSlider.value = AudioManager.sfxValue;
        }
        else
        {
            AudioManager.instance.backgroundSound.volume = 1;
            AudioManager.instance.eventSound.volume = 1;
        }
        if (vibrationState == 0)
        {
            vibrationButton.GetComponent<Image>().sprite = vibration;
        }
        else
        {
            vibrationButton.GetComponent<Image>().sprite = vibrationOff;
        }
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
        AudioManager.musicValue = musicSlider.value;
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
        AudioManager.sfxValue = sfxSlider.value;
    }

    public void VibrationImage()
    {
        AudioManager.instance.ButtonSound();
        if(vibrationButton.GetComponent<Image>().sprite == vibration)
        {
            vibrationState = 1;
            isVibrating = false;
            vibrationButton.GetComponent<Image>().sprite = vibrationOff;
        }
        else
        {
            vibrationState = 0;
            isVibrating = true;
            vibrationButton.GetComponent<Image>().sprite = vibration;
        }
        
    }
    
}
