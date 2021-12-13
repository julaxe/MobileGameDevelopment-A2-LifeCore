using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public bool facingRight = true;
    public int score = 0;
    public int hp = 100;
    void Start()
    {
        if (GameStatusSingleton.Instance != null)
        {
            GameStatusSingleton.Instance.score = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            SceneManager.LoadScene(3);
        }

        if (transform.position.y < -15.0f)
        {
            SceneManager.LoadScene(3);
        }
    }
}
