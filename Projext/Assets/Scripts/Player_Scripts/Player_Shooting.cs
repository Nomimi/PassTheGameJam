using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shooting : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject fireballPrefeb;
    private Animator anim;

    private Player_Life life;
    private ItemCollector collector;

    bool once = true;

    private void Awake()
    {
        life = GetComponent<Player_Life>();
        collector = GetComponent<ItemCollector>();
        anim = GetComponent<Animator>();
    }

    public void Shoot()
    {
        if(!anim.GetBool("shoot"))
            once = true;

        if
        (
            NonResetableValues.fruits >= 5 &&
            life.getHealth() != 0.0f &&
            once
        ){
            anim.SetBool("shoot", true);
            Instantiate(fireballPrefeb, firePoint.position, firePoint.rotation);
            NonResetableValues.fruits -= 5;
            collector.fruitsText.text = "Fruits: " + NonResetableValues.fruits;
            Invoke("stopShootingAnimation", 0.4f);
            once = false;
        } 
    }

    private void stopShootingAnimation()
    {
        anim.SetBool("shoot", false);
    }
}
