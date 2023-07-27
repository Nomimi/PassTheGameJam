using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    public TextMeshProUGUI fruitsText;

    [SerializeField] private AudioSource collectionSoundEffect;

    private void Start()
    {
        fruitsText.text = "Fruits: " + NonResetableValues.fruits;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruit"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            NonResetableValues.fruits++;
            fruitsText.text = "Fruits: " + NonResetableValues.fruits;
        }
    }
}
