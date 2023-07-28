using System.Collections;
using UnityEngine;

public class Snail_Enemy_Controller : MonoBehaviour, EnemyKiller
{
    [SerializeField] private AudioSource hitSoundEffect;
    private BoxCollider2D boxCollider;
    private CircleCollider2D circleCollider;
    private Animator anim;

    [SerializeField] private BoxCollider2D player;
    [SerializeField] private Rigidbody2D player_body;

    [SerializeField] private float bounciness = 11.5f;
    public float damage = 0.15f;

    private Enemy_Holder holder;
    private Player_Life pLife;

    int once = 1;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();

        holder = FindObjectOfType<Enemy_Holder>();
    }

    private void Update()
    {
       if(
            circleCollider.IsTouching(player) &&
            player_body.bodyType != RigidbodyType2D.Static
        ){
            player_body.velocity = new Vector2(player_body.velocity.x, bounciness);
            KillEnemy();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" && collision.gameObject.transform.position.y <= this.transform.position.y + 0.2f)
        {
            pLife = collision.gameObject.GetComponent<Player_Life>();
            pLife.reduceHealth(damage);
         
        }
    }

    public void KillEnemy()
    {
        if(once == 1)
        {
            once++;
            hitSoundEffect.Play();
        }

        gameObject.GetComponent<WaypointFollower>().enabled = false;
        anim.SetBool("Hit", true);

        for (int i = 0; i < holder.enemyArray.Length; i++)
        {
            Transform snail = holder.enemyArray[i].transform.GetChild(i);
            if(
                snail != null
            ){
                StartCoroutine(DeathDelay());
                //Destroy(holder.enemyArray[i].transform.GetChild(i).gameObject, 0.3f);
                break;
            }
        } 
    }

    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(0.8f);
        Destroy(this.gameObject);

    }
}
