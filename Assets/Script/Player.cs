using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    public Vector3 startPos;       // �X�^�[�g�ʒu
    public GameObject gameOverUI;  // �X�R�A�{���X�|�[���{�^����UI
    private bool isDead = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;   // �����ʒu��ۑ�
        gameOverUI.SetActive(false);     // �ŏ��͔�\��
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
        Debug.Log("�Q�[���I�[�o�[");
        rb.velocity = Vector2.zero;
        isDead = true;
        gameOverUI.SetActive(true); // �X�R�A�ƃ��X�|�[���{�^���\��
    }

    public void Respown()
    {
        transform.position = startPos;
        rb.velocity = Vector2.zero;
        rb.gravityScale = 1;
        transform.localScale = new Vector3(1, 1, 1);
        isDead = false;
        gameObject.SetActive(false);
    }
}
