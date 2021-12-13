using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeCore : MonoBehaviour
{
    public int hp = 255;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float ColorHp = hp / 255.0f;
        spriteRenderer.color = new Color(1.0f - ColorHp, ColorHp, ColorHp);
        if (hp <= 0)
        {
            SceneManager.LoadScene(3);
        }
    }
}
