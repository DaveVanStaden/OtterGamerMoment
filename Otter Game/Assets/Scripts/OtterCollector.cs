using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OtterCollector : MonoBehaviour
{
    private int points;
    private float MaxPoints;

    [SerializeField] private GameObject foodStuff;
    [SerializeField] private GameObject itemBox;
    [SerializeField] private Text pointText;

    private AudioSource audioSource;
    [SerializeField] private AudioClip[] SoundEffects;

    private void Start()
    {
        MaxPoints = StaticVariable.MaxScore;
        print(MaxPoints);
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        pointText.text = "= " + points.ToString();
        if (points >= MaxPoints)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.tag == "Food")
        {
            var foodstuffs = Instantiate(foodStuff, new Vector2(Random.Range(-8.3f, -6.7f), Random.Range(4.5f, 3.25f)), Quaternion.Euler(0, 0, Random.Range(-180, 180)));
            foodstuffs.GetComponent<SpriteRenderer>().sprite = collider.GetComponent<SpriteRenderer>().sprite;
            foodstuffs.GetComponent<SpriteRenderer>().sortingOrder += points;
            foodstuffs.transform.SetParent(itemBox.transform);

            if (collider.transform.name == "TwoPointFood")
            {
                points += 2;
                audioSource.clip = SoundEffects[1];
            }
            else
            {
                points++;
                audioSource.clip = SoundEffects[0];
            }
            audioSource.Play();
            Destroy(collider.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.transform.tag == "Hoop")
        {
            points += 5;
            collider.GetComponent<ParticleSystem>().Play();
            audioSource.clip = SoundEffects[2];
            audioSource.Play();
        }
    }
}