using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    public Button retry;
    void Start()
    {
        retry.onClick.AddListener(() => {
            Debug.Log("リトライボタンが押されました！");
            GameManager.Instance.Retry();
        });
    }

   
}
