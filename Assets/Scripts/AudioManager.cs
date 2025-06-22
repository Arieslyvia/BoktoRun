using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource eventSound;
    public AudioSource backgroundSound;
    public AudioClip buttonClick;
    public AudioClip basketCollide;
    public AudioClip jumpSound;
    public AudioClip scoreSound;
    public AudioClip playerDead;

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


}
