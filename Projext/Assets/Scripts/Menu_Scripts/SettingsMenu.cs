using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer MyMixer;

    [SerializeField] private Slider soundSlider;
    [SerializeField] private Slider musicSlider;

    public CanvasGroup gameRules_cg;
    public CanvasGroup gameSettings_cg;

    public Animator gameRules_anim;
    public Animator gameSettings_anim;

    private AudioSource clickSoundEffect;

    private void Awake()
    {
        clickSoundEffect = GameObject.Find("SettingsPanel").GetComponent<AudioSource>();
    }

    private void Start()
    {
        if(PlayerPrefs.HasKey("soundVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetSoundLevel();
            SetMusicLevel();
        }
    }

    public void SetSoundLevel()
    {
        float volume = soundSlider.value;
        MyMixer.SetFloat("sound", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("soundVolume", volume);
    }
    public void SetMusicLevel()
    {
        float volume = musicSlider.value;
        MyMixer.SetFloat("music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    private void LoadVolume()
    {
        soundSlider.value = PlayerPrefs.GetFloat("soundVolume");
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");

        SetSoundLevel();
        SetMusicLevel();
    }

    public void onHTPButton()
    {
        if(gameSettings_cg.alpha == 1)
        {
            clickSoundEffect.Play();
            gameSettings_anim.SetBool("Fade", true);
            gameRules_anim.SetBool("Fade", false);
            Button_Controller.SetActiveChildren("GameSettings", false);
            Button_Controller.SetActiveChildren("GameRules", true);
        }
    }
}
