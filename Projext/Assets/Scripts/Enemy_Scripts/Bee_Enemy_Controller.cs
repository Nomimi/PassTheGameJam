using UnityEngine;

public class Bee_Enemy_Controller : MonoBehaviour
{
    public float damage = 0.20f;

    private bool once = true;
    private float timer;
    private Player_Life pLife;

    private void Update()
    {
        if(gameObject.GetComponent<WaypointFollower>().currentWaypointIndex == 1 && once)
        {
            gameObject.GetComponent<WaypointFollower>().enabled = false;
            timer += Time.deltaTime;
            
            if(timer >= 2.0f)
            {
                timer = 0;
                once = false;
                gameObject.GetComponent<WaypointFollower>().enabled = true;
                gameObject.GetComponent<WaypointFollower>().speed = 10;
            }

        }

        else if(gameObject.GetComponent<WaypointFollower>().currentWaypointIndex == 0)
        {
            once = true;
            gameObject.GetComponent<WaypointFollower>().speed = 2;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            pLife = collision.gameObject.GetComponent<Player_Life>();
            pLife.reduceHealth(damage);
        }
    }
}
