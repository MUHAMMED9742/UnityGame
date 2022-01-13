using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    [SerializeField] bool onground;
    [SerializeField] int enemy_speed;
    private RaycastHit2D hit;
    private float width;
    private Rigidbody2D speed;
    [SerializeField] LayerMask obstacle;
    private static int enemy_number = 0;//bu "class" ait bir degisken
    // Start is called before the first frame update
    void Start()
    {
        
        enemy_number++;
        speed = GetComponent<Rigidbody2D>();
        width = GetComponent<SpriteRenderer>().bounds.extents.x;
        
    }

    // Update is called once per frame
    void Update()
    {
        hit = Physics2D.Raycast(transform.position+(transform.right*width/2), Vector2.down, 2f,obstacle);
        if (hit.collider != null)
        {
            onground = true;
        }
        else
        {
            onground = false;
        }
        if (onground == false)
        {
            Enemy_rotation();
        }
        speed.velocity = new Vector2(transform.right.x *enemy_speed, 0f);

    }
    /* Raycast icin cizgi ciziyor
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 real_enemy_position = transform.position + transform.right * width / 2;
        Gizmos.DrawLine(real_enemy_position, real_enemy_position + new Vector3(0f, -2f, 0f));
    }
    */
    void Enemy_rotation()
    {
        transform.eulerAngles += new Vector3(0f, 180f, 0f);// The position of the enemy is changed
        speed.velocity = new Vector2(transform.right.x * enemy_speed, 0f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<Enemy_Controller>().enemy_speed = 0;
           
            
        }
    }
}
