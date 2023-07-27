using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    // I have placed this on the root Canvas Object. For new levels, the HUD
    // and GameOverScreen need to be set.
    [SerializeField] private GameObject HUD;
    [SerializeField] private GameObject GameOverScreen;

    // Set this for the On Player Death Event, on the Player, in the inspector
    public void ActivateGameOverScreen()
    {
        GameOverScreen.SetActive(true);
        HUD.SetActive(false);
    }

    // Set this for the On Restart Event, on the Player, in the inspector
    public void DeactivateGameOverScreen()
    {
        GameOverScreen.SetActive(false);
        HUD.SetActive(true);
    }

    // ** REMINDER ** : Set this as the function for the Restart button
    // on the GameOverScreen in the Canvas.
    public void RestartLevel()
    {
        //could not fix retart system, please do this!
        //I can't either, someone please fix it I don't have time.
        Player_Life player = FindObjectOfType<Player_Life>();
        Player_Movement movement = player.GetComponent<Player_Movement>();


        player.onRestart.Invoke();
        player.GetComponent<Animator>().SetBool("spawn", true);
        player.transform.position = new Vector2(NonResetableValues.lastPositionX, NonResetableValues.lastPositionY);
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        movement.UpdateAnimationState();
        player.RestoreHealth();
        //buttons.SetActive(true); -- For Mobile
    }
}
