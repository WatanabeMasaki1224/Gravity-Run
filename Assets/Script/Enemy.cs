using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.TestTools;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public bool vertical = true;   //true:�㉺ false:���E
    public float range = 2f; //�ړ���
    private Vector2 startPos;
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (vertical)
        {
            float y = Mathf.PingPong(Time.time * speed, range) + startPos.y - range / 2;
            transform.position = new Vector2(transform.position.x, y);
        }
        else
        {
            // ���E�ɉ���
            float x = Mathf.PingPong(Time.time * speed, range) + startPos.x - range / 2;
            transform.position = new Vector2(x, transform.position.y);
        }
    }
}
