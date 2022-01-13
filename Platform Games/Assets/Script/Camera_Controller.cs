using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    [SerializeField] GameObject player_controller;
    [SerializeField] float maxX, minX;
    private Transform main_camara;
    // Start is called before the first frame update
    void Start()
    {
        main_camara = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        main_camara.transform.position = new Vector3(Mathf.Clamp(player_controller.transform.position.x,minX,maxX), transform.position.y, transform.position.z);
        
    }
}
