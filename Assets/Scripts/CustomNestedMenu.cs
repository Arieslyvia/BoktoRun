using UnityEngine;

public class CustomNestedMenu : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject sideArrow;
    public GameObject subPanelMenuMusic;
    public GameObject subPanelGameMusic;
    public GameObject menuPopUpMusic;
    public GameObject gamePopUpMusic;

   // [Header("Audio")]
    
    /*public AudioClip chasingTheHorizon;
    public AudioClip popSong;*/
    /*public AudioClip riverTheme;
    public AudioClip battleTheme1;
    public AudioClip battleTheme2;*/

    void Start()
    {
        
        /*subPanelMenuMusic.SetActive(false);
        mainPanel.SetActive(true);
        subPanelGameMusic.SetActive(false);*/
    }

    public void OnCustomizeClicked()
    {
        AudioManager.instance.ButtonSound();
        subPanelMenuMusic.SetActive(true);
        subPanelGameMusic.SetActive(true);
        sideArrow.SetActive(true);
    }

    public void OnCustomizedClickedClose()
    {
        AudioManager.instance.ButtonSound();
        subPanelMenuMusic.SetActive(false);
        subPanelGameMusic.SetActive(false);
        sideArrow.SetActive(false);
    }
    public void OnGameMusicClicked()
    {
        AudioManager.instance.ButtonSound();
        gamePopUpMusic.SetActive(true);

    }
    public void OnGameMusicClosed()
    {
        AudioManager.instance.ButtonSound();
        gamePopUpMusic.SetActive(false);

    }

    public void OnMenuMusicClicked()
    {
        AudioManager.instance.ButtonSound();
        menuPopUpMusic.SetActive(true);

    }
    public void OnMenuMusicClose()
    {
        AudioManager.instance.ButtonSound();
        menuPopUpMusic.SetActive(false);
    }

    public void OnBgButton()
    {
        AudioManager.instance.ButtonSound();
    }

    /*void PlayMusic(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.loop = true;
        audioSource.Play();
    }*/
    /* public void ChasingTheHorizon() => PlayMusic(chasingTheHorizon);
     public void PopSong() => PlayMusic(popSong);*/
    /*public void PlayRiverTheme() => PlayMusic(riverTheme);
    public void PlayBattleTheme1() => PlayMusic(battleTheme1);
    public void PlayBattleTheme2() => PlayMusic(battleTheme2);
*/

}
