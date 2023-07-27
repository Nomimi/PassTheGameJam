using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheakPointHandler : MonoBehaviour
{
    [SerializeField] private AudioSource checkPointSoundEffect;

    public int checkPointNumber = 0;

    private void Update()
    {
        if(checkPointNumber < 0)
        {
            NonResetableValues.lastPositionX += 2;
        }    
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            checkPointSoundEffect.Play();

            NonResetableValues.lastPositionX = transform.position.x;
            NonResetableValues.lastPositionY = transform.position.y;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
