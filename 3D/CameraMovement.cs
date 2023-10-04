using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform playerPos;
    [SerializeField] Vector3 cameraPos;
    [SerializeField] Vector3 cameraRot;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(cameraRot);

        offset = transform.position - playerPos.position;
    }
    void Update()
    {
        transform.position = playerPos.position + cameraPos;

        transform.position = playerPos.position + -playerPos.forward * offset.magnitude;

        transform.LookAt(playerPos);
    }

    private Vector3 offset; // ī�޶�� �÷��̾� ���� ��� ��ġ

}
