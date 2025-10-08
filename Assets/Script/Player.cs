using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private bool isDead = false;
    private Animator animator;
    public LayerMask groundLayer;
    public Transform groundCheck; 
    public float checkRadius = 0.2f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!isDead)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            animator.SetBool("isRunning", true);
        }

        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Gravity();
        }

    }

    void Gravity()
    {
        rb.gravityScale *= -1;
        transform.localScale = new Vector3(-1,-transform.localScale.y,1);
       
    }

    bool IsGrounded()
    {
        // 円状の判定で足元に地面があるか確認
        return Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
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
        animator.SetBool("isRunning", false); // ← 停止
        GameManager.Instance.GameOver();
    }

}
