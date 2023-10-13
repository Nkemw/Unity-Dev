using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    private float speed = 10f;
    private Vector3 dir;

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }


    public void BulletPosInit(Vector3 pos)
    {
        transform.position = new Vector3(pos.x, pos.y, pos.z);
    }
    public void BulletDirInit(Vector3 dir)
    {
        this.dir = dir;
        //dir.Normalize();
    }

    public void BulletRotInit(Vector3 dir)
    {
        //this.dir = new Vector3(x, y, 0f);
        //dir.Normalize();

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90f;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
    /*private void OnCollisionEnter2D(Collision collision)
    {
        ObjectPool.instance.ReturnBullet(gameObject);
    }*/

    private void OnCollisionExit2D(Collision2D collision)
    {
        ObjectPool.instance.ReturnBullet(gameObject);
    }
}
