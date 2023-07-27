using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Slider fireBar;
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

            if (NonResetableValues.fruits > 5)
            {
                fireBar.value = fireBar.maxValue;
            }
            else { fireBar.value = NonResetableValues.fruits; }
            
        }
    }
}
