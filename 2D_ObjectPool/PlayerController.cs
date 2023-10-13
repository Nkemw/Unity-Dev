using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 dir;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            dir.z = 0f;
            dir.Normalize();

            GameObject bullet = ObjectPool.instance.TakeBullet();

            if (bullet != null)
            {
                bullet.GetComponent<BulletMove>().BulletPosInit(transform.position);

                bullet.GetComponent<BulletMove>().BulletDirInit(dir);

                bullet.GetComponent<BulletMove>().BulletRotInit(dir);
            }

        }
    }
}
