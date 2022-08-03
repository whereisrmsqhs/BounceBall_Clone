using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMove : MonoBehaviour
{
    float playerSpeed = 4f;
    int jumpPower = 7;
    public Rigidbody2D rigid;
    BoxCollider2D collider;
    CircleCollider2D collider_circle;
    SpriteRenderer srenderer;
    int cur_stage;

    // Start is called before the first frame update
    void Start()
    {
        cur_stage = 2;
        rigid = GetComponent<Rigidbody2D>();
        //collider = GetComponent<BoxCollider2D>();
       // srenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigid.gravityScale = 2;
            transform.rotation = Quaternion.identity;
            transform.Translate(new Vector3(playerSpeed * Time.deltaTime, 0, 0));
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigid.gravityScale = 2;
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            transform.Translate(new Vector3(playerSpeed * Time.deltaTime, 0, 0));
        }

        if (Mapmake.total_coins[cur_stage] == 1)
        {
            cur_stage++;
            SceneManager.LoadScene(cur_stage);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        srenderer = collision.gameObject.GetComponent<SpriteRenderer>();
        collider = collision.gameObject.GetComponent<BoxCollider2D>();
        collider_circle = collision.gameObject.GetComponent<CircleCollider2D>();

       if(collision.gameObject.tag == "block")
        {
            rigid.velocity = new Vector2(0, jumpPower);
        }
        if(collision.gameObject.tag == "crack")
        {
            //rigid.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
            rigid.velocity = new Vector2(0, jumpPower);
            srenderer = collision.gameObject.GetComponent<SpriteRenderer>();
            srenderer.color = new Color(1, 1, 1, 0);
            collider.isTrigger = true;
            //Destroy(collision.gameObject, 0f);
        }
        if(collision.gameObject.tag == "uparrow")
        {
            rigid.velocity = new Vector2(0, jumpPower+2);
        }
        if (collision.gameObject.tag == "rightarrow")
        {
            rigid.gravityScale = 0;
            transform.position = new Vector2(collision.transform.position.x + 1f, collision.transform.position.y);
            rigid.velocity = new Vector2(jumpPower, 0);
        }
        if (collision.gameObject.tag == "bomb")
        {
            transform.position = new Vector2(0.5f, 0);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        srenderer = collision.gameObject.GetComponent<SpriteRenderer>();
        
        if (collision.gameObject.tag == "crack")
        {
            srenderer = collision.gameObject.GetComponent<SpriteRenderer>();
            srenderer.color = new Color(1, 1, 1, 0);
            //collider.isTrigger = true;
            //Destroy(collision.gameObject, 0f);
        }
        if (collision.gameObject.tag == "coin")
        {
            srenderer = collision.gameObject.GetComponent<SpriteRenderer>();
            srenderer.color = new Color(1, 1, 1, 0);

            Destroy(this);

            
            Mapmake.total_coins[cur_stage]--;
            
        }

    }
}
