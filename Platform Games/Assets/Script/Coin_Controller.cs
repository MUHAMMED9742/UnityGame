using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text score_number;
    private int score=0;
    [SerializeField] AudioClip coin;

    private void Update()
    {
        transform.Rotate(0f, 5f, 0f);
    }

  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<AudioSource>().Play();
            int score = int.Parse(score_number.text);
            score += 50;
            score_number.text = score.ToString();
            Destroy(gameObject);
           
        }
    }
    
    


}
