using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{

    [SerializeField] private Image skin;
    [SerializeField] private List<Sprite> skins = new List<Sprite>();
    [SerializeField] private Animator transition;

    private AudioSource slideSoundEffect;

    private float transitionTime = 1f;

    private void Awake()
    {
        slideSoundEffect = GameObject.Find("SkinPanel").GetComponent<AudioSource>();
        skin.sprite = skins[PlayerPrefs.GetInt("skinIndex")];
    }

    public void NextOption()
    {
        slideSoundEffect.Play();
        NonResetableValues.selectedSkin += 1;
        if(NonResetableValues.selectedSkin == skins.Count)
        {
            NonResetableValues.selectedSkin = 0;
        }
        PlayerPrefs.SetInt("skinIndex", NonResetableValues.selectedSkin);
        skin.sprite = skins[NonResetableValues.selectedSkin];
    }

    public void BackOption()
    {
        slideSoundEffect.Play();
        NonResetableValues.selectedSkin -= 1;
        if(NonResetableValues.selectedSkin < 0)
        {
            NonResetableValues.selectedSkin = skins.Count - 1;
        }
        PlayerPrefs.SetInt("skinIndex", NonResetableValues.selectedSkin);
        skin.sprite = skins[NonResetableValues.selectedSkin];
    }

    public void OnStartButton(string LevelToLoad)
    {
        StartCoroutine(loadLevel(LevelToLoad));
    }

    IEnumerator loadLevel(string LevelToLoad)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadSceneAsync(LevelToLoad);
    }

}
