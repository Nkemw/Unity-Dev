using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    private Queue<GameObject> bulletQueue = new Queue<GameObject>();

    [SerializeField] GameObject bullet;

    [SerializeField] int maxBulletCount;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(this.gameObject);
        }

        InitBullet();
    }

    void InitBullet()
    {
        for(int i = 0; i < maxBulletCount; i++)
        {
            CreateBullet();
        }
    }
    public GameObject TakeBullet()
    {
        //Debug.Log(bulletCount);
        /*if(bulletQueue.Count == 0)
        {
            CreateBullet();
        }*/

        if (bulletQueue.Count != 0)
        {
            GameObject takeBullet = bulletQueue.Dequeue();
            takeBullet.SetActive(true);
            return takeBullet;
        }

        return null;
    }

    public void CreateBullet()
    {
        GameObject createdBullet = Instantiate(bullet);
        bulletQueue.Enqueue(createdBullet);
        //bulletCount++;
    }

    public void ReturnBullet(GameObject bullet)
    {
        Debug.Log("Return");
        bullet.SetActive(false);
        bulletQueue.Enqueue(bullet);
    }
    
}
