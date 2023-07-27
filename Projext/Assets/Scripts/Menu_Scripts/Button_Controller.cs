using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Button_Controller : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image img;
    [SerializeField] private Sprite _default;
    [SerializeField] private Sprite _pressed;

    private CanvasGroup buttonP_cg;
    private CanvasGroup skinP_cg;
    private CanvasGroup settingsP_cg;

    private Animator buttonP_anim;
    private Animator skinP_anim;
    private Animator settingsP_anim;

    private AudioSource clickSoundEffect;

    private void Awake()
    {
        skinP_anim = GameObject.Find("SkinPanel").GetComponent<Animator>();
        buttonP_anim = GameObject.Find("ButtonPanel").GetComponent<Animator>();
        settingsP_anim = GameObject.Find("SettingsPanel").GetComponent<Animator>();

        skinP_cg = GameObject.Find("SkinPanel").GetComponent<CanvasGroup>();
        buttonP_cg = GameObject.Find("ButtonPanel").GetComponent<CanvasGroup>();
        settingsP_cg = GameObject.Find("SettingsPanel").GetComponent<CanvasGroup>();

        clickSoundEffect = GameObject.Find("ButtonPanel").GetComponent<AudioSource>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        img.sprite = _pressed;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
       img.sprite = _default;
    }

    public void OnPlayButton()
    {
        if(buttonP_cg.alpha == 1f)
        {
            clickSoundEffect.Play();
            skinP_anim.SetBool("Fade", false);
            buttonP_anim.SetBool("Fade", true);
        }
    }

    public void OnSettingsButton()
    {
        if(buttonP_cg.alpha == 1f)
        {
            clickSoundEffect.Play();
            settingsP_anim.SetBool("Fade", false);
            buttonP_anim.SetBool("Fade", true);
        }
    }

    public void OnQuitButton()
    {
        clickSoundEffect.Play();
        Application.Quit();
    }

    public void OnSkinPanelBackButton()
    {
        if(skinP_cg.alpha == 1)
        {
            clickSoundEffect.Play();
            skinP_anim.SetBool("Fade", true);
            buttonP_anim.SetBool("Fade", false);
        }
    }

    public void OnSettingsPanelBackButton()
    {
        if(GameObject.FindObjectOfType<SettingsMenu>().gameRules_anim.GetBool("Fade"))
        {
            if(settingsP_cg.alpha == 1)
            {
                clickSoundEffect.Play();
                settingsP_anim.SetBool("Fade", true);
                buttonP_anim.SetBool("Fade", false);
            }
        }
        if(GameObject.FindObjectOfType<SettingsMenu>().gameSettings_anim.GetBool("Fade"))
        {
            if(GameObject.FindObjectOfType<SettingsMenu>().gameRules_cg.alpha == 1)
            {
                clickSoundEffect.Play();
                GameObject.FindObjectOfType<SettingsMenu>().gameSettings_anim.SetBool("Fade", false);
                GameObject.FindObjectOfType<SettingsMenu>().gameRules_anim.SetBool("Fade", true);
                SetActiveChildren("GameSettings", true);
                SetActiveChildren("GameRules", false);
            }
        }
    }

    public static void SetActiveChildren(string name, bool active)
    {
        for(int i = 0; i < GameObject.Find(name).transform.childCount; i++)
        {
            GameObject.Find(name).transform.GetChild(i).gameObject.SetActive(active);
        }
    }
}
