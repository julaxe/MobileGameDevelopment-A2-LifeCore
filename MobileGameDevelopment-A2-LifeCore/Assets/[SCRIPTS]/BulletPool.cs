
using System;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int initialAmountOfBullets;
    private List<GameObject> listOfBullets;

    private void Start()
    {
        listOfBullets = new List<GameObject>();
        InitializePool();
    }

    public void ReturnBulletToThePool(GameObject bullet)
    {
        bullet.SetActive(false);
    }
    
    public GameObject GetBulletFromPool()
    {
        GameObject bullet = listOfBullets.Find(x =>
            x.activeSelf == false);
        if (bullet == null)
        {
            bullet =  AddANewBullet();
        }
        bullet.SetActive(true);
        return bullet;
    }

    private GameObject AddANewBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.SetActive(false);
        listOfBullets.Add(bullet);
        return bullet;
    }
    private void InitializePool()
    {
        for (int i = 0; i < initialAmountOfBullets; i++)
        {
            AddANewBullet();
        }
    }
    
}
