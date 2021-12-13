using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool facingRight = false;

    public int hp = 100;
    // Start is called before the first frame update
    public void Start()
    {
        hp = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp < 0)
        {
            this.gameObject.SetActive(false);
            SoundManager.Instance.Play("EnemyDie");
        }
    }
}
