using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Time_Controller : MonoBehaviour
{
    public Text time_number;
    [SerializeField] float time_adjustment;
    private bool game_active;
    // Start is called before the first frame update
    void Start()
    {
        game_active = true;
        time_number.text = time_number.ToString();
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (game_active == true)
        {
            time_adjustment -= Time.deltaTime;
            time_number.text = ((int)time_adjustment).ToString();
            if (time_adjustment < 0)
            {
                Time_Control();

            }
        }
    }
    public void Time_Control()
    {
    
        game_active = false;
        time_adjustment = 1;
        gameObject.GetComponent<Player_Controller>().Die();
    }

}
