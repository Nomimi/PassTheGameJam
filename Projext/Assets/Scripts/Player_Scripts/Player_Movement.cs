using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] private LayerMask jumpableGround;
    
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    private Transform tf;
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;

    private float dirX;
    private SpriteRenderer sprite;

    private enum MovementState { idle, running, jumping, falling }

    [SerializeField] private AudioSource jumpSoundEffect;

    private void Awake()
    {
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        NonResetableValues.lastPositionX = transform.position.x;
        NonResetableValues.lastPositionY = transform.position.y;
    }

    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        if(rb.bodyType != RigidbodyType2D.Static)
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationState();
    }

    public void UpdateAnimationState()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            tf.eulerAngles = Vector2.zero;
            // sprite.flipX = false; -- Doesn't flip fire-point
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            tf.eulerAngles = new Vector2(0, 180f);
            // sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }


    public bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}