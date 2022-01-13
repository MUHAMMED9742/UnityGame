using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_Control : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject effect;
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Instantiate(effect, collision.gameObject.transform.position, Quaternion.identity);
        }
        else if(collision.gameObject.tag!="Player")
        {
            Destroy(gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
