using UnityEngine;

public class CustomNestedMenu : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject subPanelMenuMusic;
    public GameObject subPanelBattleMusic;

    [Header("Animators")]
    public Animator mainAnimator;
    public Animator menuMusicAnimator;
    public Animator battleMusicAnimator;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip forestTheme;
    public AudioClip nightSkyTheme;
    public AudioClip riverTheme;
    public AudioClip battleTheme1;
    public AudioClip battleTheme2;

    void Start()
    {
        ShowMainPanel();
    }

    public void OnMenuMusicClicked()
    {
        PlayAnimation(mainAnimator, "PanelClose");
        PlayAnimation(menuMusicAnimator, "PanelOpen");
    }

    public void OnBattleMusicClicked()
    {
        PlayAnimation(mainAnimator, "PanelClose");
        PlayAnimation(battleMusicAnimator, "PanelOpen");
    }

    public void ShowMainPanel()
    {
        PlayAnimation(menuMusicAnimator, "PanelClose");
        PlayAnimation(battleMusicAnimator, "PanelClose");
        PlayAnimation(mainAnimator, "PanelOpen");
    }

    void PlayAnimation(Animator animator, string triggerName)
    {
        if (animator != null)
        {
            animator.SetTrigger(triggerName);
        }
    }

    public void PlayForestTheme() => PlayMusic(forestTheme);
    public void PlayNightSkyTheme() => PlayMusic(nightSkyTheme);
    public void PlayRiverTheme() => PlayMusic(riverTheme);
    public void PlayBattleTheme1() => PlayMusic(battleTheme1);
    public void PlayBattleTheme2() => PlayMusic(battleTheme2);

    void PlayMusic(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.loop = true;
        audioSource.Play();
    }
}
