using System;
using System.Collections;
using System.Collections.Generic;
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
                Destroy(holder.enemyArray[i].transform.GetChild(i).gameObject, 0.3f);
                break;
            }
        } 
    }
}
