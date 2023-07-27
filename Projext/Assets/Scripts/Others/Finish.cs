using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Finish : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private Animator transition;
    private AudioSource finishSoundEffect;

    private bool levelCompleted = false;

    private float transitionTime = 1f;

    private void Start()
    {
        levelText.text = "Level: " + NonResetableValues.level;
        finishSoundEffect = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && !levelCompleted)
        {
            finishSoundEffect.Play();
            levelCompleted = true;
            NonResetableValues.respawnLevelFruits = NonResetableValues.fruits;
            NonResetableValues.level++;
            StartCoroutine(loadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }

    IEnumerator loadLevel(int index)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(index);
    }
}
