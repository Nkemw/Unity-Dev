using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    [SerializeField] float mouseSensivity = 20f;
    private void FixedUpdate()
    {
        float verticalMovement = Input.GetAxis("Vertical");
        float horizontalMovement = Input.GetAxis("Horizontal");

        transform.position += (transform.forward * verticalMovement + transform.right * horizontalMovement) * Time.deltaTime * moveSpeed;

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        //
        //mouseX = Mathf.Clamp(mouseX, -90f, 90f);

        //transform.Rotate(new Vector3(MouseY* mouseSensivity, MouseX* mouseSensivity, 0));
        Vector3 currentRotation = transform.rotation.eulerAngles;
        // 마우스 입력에 따라 Y축 회전
        transform.rotation = Quaternion.Euler(currentRotation.x - mouseY * mouseSensivity, currentRotation.y + mouseX * mouseSensivity, 0);
    }
}
