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
            Debug.Log("���g���C�{�^����������܂����I");
            GameManager.Instance.Retry();
        });
    }

   
}
