using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public Text scoreText;
    public Text highScoreText;
    private int savedScore;

    public GameObject homeMenu;
    public GameObject settingMenu;
    public GameObject pauseMenu;
    public GameObject gameMenu;
    public GameObject optionGo;
    public GameObject restartBt;
    public GameObject menuBt;

    
    public static bool isRestarting;

    private void Start()
    {
        if (isRestarting == true)
        {
            homeMenu.SetActive(false);
            settingMenu.SetActive(false);
            pauseMenu.SetActive(false);
            gameMenu.SetActive(true);
            


        }
        else
        {
            homeMenu.SetActive(true);
            settingMenu.SetActive(false);
            pauseMenu.SetActive(false);
            gameMenu.SetActive(false);
            AudioManager.instance.MenuBgSound();
            AudioManager.instance.backgroundSound.Play();

        }
        savedScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = savedScore.ToString();
    }
    public void StartGame()
    {
        AudioManager.instance.ButtonSound();
        AudioManager.instance.GamePlayMusic();
        AudioManager.instance.ChangegameClip(AudioManager.instance.gamePlayBgSound);
        AudioManager.instance.backgroundSound.Play(); //Only Plays At Start
        Time.timeScale = 1;
        homeMenu.SetActive(false);
        gameMenu.SetActive(true);
        pauseMenu.SetActive(false);

    }

    public void QuitGame()
    {
        AudioManager.instance.ButtonSound();
        Application.Quit();
    }

    public void SettingOpen()
    {
       AudioManager.instance.ButtonSound();
        homeMenu.SetActive(false);
        settingMenu.SetActive(true);
       
    }


    public void BackButton()
    {
       AudioManager.instance.ButtonSound();
        homeMenu.SetActive(true);
        settingMenu.SetActive(false);
    }
    public void MenuBt()
    {
        AudioManager.instance.ButtonSound();
        //AudioManager.instance.backgroundSound.enabled = false;
        AudioManager.instance.backgroundSound.enabled = true;    
        homeMenu.SetActive(true);
        pauseMenu.SetActive(false);
        gameMenu.SetActive(false);

    }

    public void ReStart()
    {
        AudioManager.instance.ButtonSound();
        Time.timeScale = 1f;
        isRestarting = true;
        var sc = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sc);
    }

    public void PauseGame()
    {
       AudioManager.instance.ButtonSound();
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        AudioManager.instance.ButtonSound();
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void GoHome()
    {
        isRestarting = false;
        AudioManager.instance.ButtonSound();
        AudioSetting.isQuit = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = score.ToString();

        if (score > savedScore)
        {
            PlayerPrefs.SetInt("HighScore", score);

            savedScore = PlayerPrefs.GetInt("HighScore");
            highScoreText.text = savedScore.ToString();

        }
    }
    
}

