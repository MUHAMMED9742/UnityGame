using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Control : MonoBehaviour
{
    [SerializeField] GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.GetComponent<Player_Controller>().onground = true;
       
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        player.GetComponent<Player_Controller>().onground = false;
    }
}
