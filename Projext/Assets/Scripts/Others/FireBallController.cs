using UnityEngine;

public class FireBallController : MonoBehaviour
{
    [SerializeField]  private float speed = 20f;
    
    private Rigidbody2D rb;
    private Animator anim;
    private CircleCollider2D circleCollider;
    
    private Rotate rotate;
    [SerializeField] private GameObject snail;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        circleCollider =  GetComponent<CircleCollider2D>();
        rotate = GetComponent<Rotate>();
    }

    private void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(
            collider.CompareTag("Platform") ||
            collider.CompareTag("Trap")
        ){
            rb.velocity = new Vector2(0f, rb.velocity.y);
            rotate.enabled = false;
            anim.SetTrigger("Hit");
            Destroy(gameObject, 0.45f);
        }

        if(
            collider.CompareTag("Enemy") ||
            collider.CompareTag("KillableEnemy")
        ){
            rb.velocity = new Vector2(0f, rb.velocity.y);
            rotate.enabled = false;
            anim.SetTrigger("Hit");

            Collision(collider);

            Destroy(gameObject, 0.45f);
        }
    }

    private void Collision(Collider2D collider)
    {
        if(collider.transform.CompareTag("KillableEnemy"))
        {
            EnemyKiller killer = collider.GetComponent<EnemyKiller>();
            killer.KillEnemy();
        }
    }
}
