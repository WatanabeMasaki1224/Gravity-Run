using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private bool isDead = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!isDead)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Gravity();
        }
    }

    void Gravity()
    {
        rb.gravityScale *= -1;
        transform.localScale = new Vector3(1,-transform.localScale.y,1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("ゲームオーバー");
        rb.velocity = Vector2.zero;
        isDead = true;
        GameManager.Instance.GameOver();
    }

}
