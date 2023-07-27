using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private float trapDamage;
    [SerializeField] private Player_Life pLife;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            pLife.reduceHealth(trapDamage);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            pLife.reduceHealth(trapDamage * Time.deltaTime);
        }
    }
}
