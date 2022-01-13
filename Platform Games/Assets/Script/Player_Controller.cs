using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{
    private float my_speed;
    private Rigidbody2D mybody;
    [SerializeField] int speed;
    private Vector3 player_scale;// Oyuncunun Transform localscale(dönüþ yönü) için oluþturulmuþtur.
    public bool onground;
    private bool canDoublejump;
    [SerializeField] float jump_power;
    [SerializeField] GameObject arrow;
    [SerializeField]  double current_time;
    [SerializeField] bool attack_control;
    private Animator my_animation;
    private Vector3 player_position;
    [SerializeField] int arrow_number;
    [SerializeField] Text arrow_text;
    [SerializeField] AudioClip die_music;
    [SerializeField] GameObject finish;
    [SerializeField] GameObject win_panel, loose_panel;
    void Start()
    {
        arrow_text.text = arrow_number.ToString();
        
        attack_control = false;
        player_scale = transform.localScale;
        mybody = GetComponent<Rigidbody2D>();
        my_animation = GetComponent<Animator>();
        player_position = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
        my_speed = Input.GetAxis("Horizontal");
        mybody.velocity = new Vector2(my_speed * speed, mybody.velocity.y);
        my_animation.SetFloat("Speed", Mathf.Abs(my_speed));
       
        if (my_speed != 0)
        {
            Player_Rotation();

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump_Player();
        }
        if (Input.GetMouseButtonDown(0) && arrow_number>0)
        {
            if (attack_control==false)
            {
                my_animation.SetTrigger("Attack");
                attack_control = true;
                Invoke("Arrow", 0.5f);
           
               
            }
        }
        if (attack_control == true)
        {

            current_time -= Time.deltaTime;
        }
        else
        {
            current_time = 1.5;
        }
        if (current_time < 0)
        {
            attack_control = false;
        }
      
    









    }
    void Player_Rotation()
    {
        if (my_speed > 0)
        {
            transform.localScale = new Vector3(player_scale.x, player_scale.y, player_scale.z);
        }
        else if (my_speed < 0)
        {
            transform.localScale = new Vector3(-player_scale.x, player_scale.y, player_scale.z);
        }

    }
    void Jump_Player()
    {

        if (onground == true)
        {
            my_animation.SetTrigger("Jump");

            mybody.velocity = new Vector2(mybody.velocity.x, jump_power);
            canDoublejump = true;
        }
        else
        {
            if (canDoublejump == true)
            {
                mybody.velocity = new Vector2(mybody.velocity.x, jump_power);
                canDoublejump = false;
            }
        }
    }
    void Arrow()
    {

            GameObject our_arrow = Instantiate(arrow, transform.position, Quaternion.identity);
            our_arrow.transform.parent = GameObject.Find("Arrows").transform;
            if (my_speed > 0 || (my_speed == 0 && transform.localScale.x > 0))
            {
            our_arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(5f, 0f);
            our_arrow.transform.localScale = new Vector3(our_arrow.transform.localScale.x, our_arrow.transform.localScale.y, our_arrow.transform.localScale.z);
            player_position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        }
        else if (my_speed < 0 || (my_speed == 0 && transform.localScale.x < 0))
            {
                our_arrow.transform.localScale = new Vector3(-our_arrow.transform.localScale.x, our_arrow.transform.localScale.y, our_arrow.transform.localScale.z);
                our_arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(-5f, 0f);
                player_position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        }
        arrow_number--;
        arrow_text.text = arrow_number.ToString();
        


    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            mybody.velocity = new Vector2(0f, 0f);
            Die();
        }
        else if (collision.gameObject.CompareTag("Finish"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(Wait_Win_Panel());
        }
    }
    public void Die()
    {
        GameObject.Find("Sound Controller").GetComponent<AudioSource>().clip = null;
        GameObject.Find("Sound Controller").GetComponent<AudioSource>().PlayOneShot(die_music);
        player_position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        GetComponent<Player_Controller>().enabled = false;
        gameObject.GetComponent<Time_Controller>().enabled=false;
        my_animation.SetTrigger("Die");
        StartCoroutine(Wait_Loose_Panel());





    }
    IEnumerator Wait_Win_Panel()
    {
        gameObject.GetComponent<Time_Controller>().enabled = false;
        yield return new WaitForSecondsRealtime(1f);
        win_panel.SetActive(true);
    }
    IEnumerator Wait_Loose_Panel()
    {
        gameObject.GetComponent<Time_Controller>().enabled = false;
        yield return new WaitForSecondsRealtime(1f);
        loose_panel.SetActive(true);
    }

}
