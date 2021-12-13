using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    private BulletPool enemyPool;
    private double timer;
    public double cooldownEnemySpawner= 2.0f;
    public int MaxAmountOfEnemies = 5;
    void Start()
    {
        enemyPool = GetComponent<BulletPool>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > cooldownEnemySpawner)
        {
            if (enemyPool.GetAmountOfActives() < MaxAmountOfEnemies)
            {
                GenerateAnEnemy();
                timer = 0;
            }
        }

        timer += Time.deltaTime;
    }

    private void GenerateAnEnemy()
    {
        GameObject enemy = enemyPool.GetBulletFromPool();
        int rightSide = Random.Range(0, 1);
        float Xposition, Yposition;
        if (rightSide == 1)
        {
            Xposition = 15.0f;
        }
        else
        {
            Xposition = -15.0f;
        }
        Yposition = Random.Range(-10.0f, 10.0f);
        enemy.transform.position = new Vector3(Xposition, Yposition, 0.0f);
        enemy.GetComponent<Enemy>().Start();
    }
}
