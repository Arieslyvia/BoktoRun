using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource eventSound;
    public AudioSource backgroundSound;

    public AudioClip mainMenuClip;
    public AudioClip buttonClick;
    public AudioClip basketCollide;
    public AudioClip jumpSound;
    public AudioClip scoreSound;
    public AudioClip playerDead;
    public AudioClip gamePlayBgSound;
    //public AudioSource gameaudioSource;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

    }




    public void PlaySound(AudioClip sounds)
    {
        eventSound.PlayOneShot(sounds);
    }


    public void ButtonSound()
    {
        PlaySound(buttonClick);
    }
    public void Jumpsound()
    {
        PlaySound(jumpSound);
    }

    public void BasketCollide()
    {
        PlaySound(basketCollide);
    }

    public void ScoreSound()
    {
        PlaySound(scoreSound);
    }

    public void PlayerDeadSound()
    {
        PlaySound(playerDead);
    }

    public void ChangeBgClip(AudioClip menuClip)
    {
        backgroundSound.clip = menuClip;
        backgroundSound.Play();
        mainMenuClip = menuClip;
    }

    //For Main Menu Choosing the music and playing
    public void ChangegameClip(AudioClip gameClip)
    {
        //backgroundSound.clip = gameClip;
        //backgroundSound.Play();
        gamePlayBgSound = gameClip;
    }

    //Game music(Only Choosing)
    public void GamePlayMusic()
    {
        /*backgroundSound.enabled = false;
        backgroundSound.clip = gamePlayBgSound;
        backgroundSound.enabled = true;*/
        backgroundSound.enabled = false;
        backgroundSound.clip = gamePlayBgSound;
        backgroundSound.enabled = true;
    }

    public void MenuBgSound()
    {
        backgroundSound.enabled = false;
        backgroundSound.clip = mainMenuClip;
        backgroundSound.enabled = true;
    }
}
