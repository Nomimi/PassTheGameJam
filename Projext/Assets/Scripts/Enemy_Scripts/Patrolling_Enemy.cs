using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling_Enemy : MonoBehaviour
{
    [SerializeField] private Snail_Enemy_Controller snail_Enemy;
    private SpriteRenderer sprite;

    public BoxCollider2D boxCollider;
    public CircleCollider2D circleCollider;

    bool flipped;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();

        boxCollider = GetComponent<BoxCollider2D>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        if(gameObject.GetComponent<WaypointFollower>().currentWaypointIndex == 0)
        {
            sprite.flipX = false;
            if(flipped)
            {
                if(circleCollider != null)
                    circleCollider.offset *= -1;
                boxCollider.offset = new Vector2(
                    boxCollider.offset.x * -1,
                    boxCollider.offset.y   
                );

                flipped = false;
            }
        }

        else
        {
            sprite.flipX = true;
            if(!flipped)
            {
                if(circleCollider != null)
                    circleCollider.offset *= -1;
                boxCollider.offset = new Vector2(
                    boxCollider.offset.x * -1,
                    boxCollider.offset.y
                );

                flipped = true;
            }
        }
    }
}
