using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject HUD;
    [SerializeField] private GameObject pauseMenuScreen;
    [SerializeField] private Player_Movement move;

    private bool clickedResumeButton = false;

    private void Update()
    {
        if(clickedResumeButton && move.IsGrounded())
        {
            clickedResumeButton = false;
        }
    }

    public void PauseGame()
    {
        //Please, start the game and then pause it, then press the arrow keys, please fix this!
        HUD.SetActive(false);

        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        clickedResumeButton = true;

        HUD.SetActive(true);

        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }

    public void GoToMenu()
    {
        NonResetableValues.fruits = 0;
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync("Main Menu");
    }
}
