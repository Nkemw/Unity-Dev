using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform playerPos;
    [SerializeField] Vector3 cameraPos;
    [SerializeField] Vector3 cameraRot;

    private Vector3 offset;

    [SerializeField] PlayerMovement player;
    private void Start()
    {
        transform.rotation = Quaternion.Euler(cameraRot);

        offset = transform.position - playerPos.position;
    }
    void Update()
    {
        CameraRotate();
        CameraMove();
    }

    void CameraMove()
    {
        transform.position = playerPos.position - transform.forward * offset.magnitude;
    }

    void CameraRotate()
    {
        transform.rotation = Quaternion.Euler(player.RotateVector);
    }
}