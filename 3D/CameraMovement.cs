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

    [SerializeField] float softness = 0.4f;
    private void Start()
    {
        transform.rotation = Quaternion.Euler(cameraRot);

        offset = transform.position - playerPos.position;
    }
    void FixedUpdate()
    {
        CameraRotate();
        CameraMove();
    }

    void CameraMove()
    {
        Vector3 targetPosition = playerPos.position - transform.forward * offset.magnitude;
        transform.position = Vector3.Slerp(transform.position, targetPosition, softness);
    }

    void CameraRotate()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(player.RotateVector), softness);
    }
}