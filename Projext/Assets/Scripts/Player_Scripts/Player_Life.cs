using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player_Life : MonoBehaviour
{
    //private CheakPointHandler spawner;
    //private Player_Movement movement;

    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] private AudioSource deathSoundEffect;
    
    // For Mobile
    [SerializeField] private GameObject buttons;
    [SerializeField] private GameObject HUD;

    [Header("Pass in health bar sprites from HUD")]
    public Slider healthBar;
    public Image fill;

    public UnityEvent onPlayerDeath;
    public UnityEvent onRestart;
    
    private Rigidbody2D rb;
    private Animator anim;
    //private SpriteRenderer sprite;

    private float health = 1f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        //movement = GetComponent<Player_Movement>();
        //spawner = FindObjectOfType<CheakPointHandler>();
    }

    private void Start()
    {
        healthBar.value = health;
    }

    // Added a Damage Dealer to all enemies and traps to access this function.
    public void reduceHealth(float damage)
    {
       setHealth(health - damage/100, true);

        if(health <= 0)
        {
            setHealth(0, false);
        }
    }

    // Called during a level restart
    public void RestoreHealth()
    {
        setHealth(1f, true);
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetBool("spawn", false);
        anim.SetTrigger("death");
        deathSoundEffect.Play();
        Invoke("ShowGameOverScreen", 1.0f);
    }

    private void ShowGameOverScreen()
    {
        onPlayerDeath.Invoke();
    }

    // GUTTED THIS TO FIX RESTART: PTG - DAY3
    //public void RestartLevel()
    //{
    //    //could not fix retart system, please do this!
    //    //I can't either, someone please fix it I don't have time.
    //    Player_Life player = FindObjectOfType<Player_Life>();
    //    Player_Movement movement = player.GetComponent<Player_Movement>();


    //    player.onRestart.Invoke();
    //    player.GetComponent<Animator>().SetBool("spawn", true);
    //    player.transform.position = new Vector2(NonResetableValues.lastPositionX, NonResetableValues.lastPositionY);
    //    player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    //    movement.UpdateAnimationState();
    //    //buttons.SetActive(true); -- For Mobile
    //    player.setHealth(1, true);
    //}

    private void setHealth(float health, bool enable)
    {
        this.health = health;
        fill.enabled = enable;
        healthBar.value = this.health;

        if(this.health <= 0)
        {
            Die();
        }
    }

    public float getHealth()
    {
        return health;
    }
    
}
