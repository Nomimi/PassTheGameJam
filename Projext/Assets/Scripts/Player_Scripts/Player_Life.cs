using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Player_Life : MonoBehaviour
{
    private CheakPointHandler spawner;
    private Player_Movement movement;
    private Player_Collision col;

    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] private AudioSource deathSoundEffect;
    
    [SerializeField] private GameObject buttons;
    [SerializeField] private GameObject HUD;

    public Slider healthBar;
    public Image fill;
    
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;

    private float health = 1f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>(); 

        col =  GetComponent<Player_Collision>();
        movement = GetComponent<Player_Movement>();
        spawner = FindObjectOfType<CheakPointHandler>();
    }

    private void Start()
    {
        healthBar.value = health;
    }

    public void reduceHealth(float damage)
    {
       setHealth(health - damage, true);

        if(health <= 0)
        {
            setHealth(0, false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.CompareTag("Trap"))
        {
            setHealth(0, false);
        }
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
        buttons.SetActive(false);
        HUD.SetActive(false);
        GameOverScreen.SetActive(true);
    }

    public void RestartLevel()
    {
        //could not fix retart system, please so this!
        //I can't either, someone please fix it I don't have time.
        sprite.enabled = true;
        anim.SetBool("spawn", true);
        transform.position = new Vector2(NonResetableValues.lastPositionX, NonResetableValues.lastPositionY);
        rb.bodyType = RigidbodyType2D.Dynamic;
        movement.UpdateAnimationState();
        GameOverScreen.SetActive(false);
        buttons.SetActive(true);
        HUD.SetActive(true);
        setHealth(1, true);
    }

    public void setHealth(float health, bool enable)
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
