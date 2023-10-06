using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    [SerializeField] float mouseSensivity = 20f;

    private Vector3 rotateVector;
    public Vector3 RotateVector { get; set; }

    [SerializeField] float rotateLimitX = 85f;

    private void Start()
    {
        RotateVector = transform.forward;
    }
    private void FixedUpdate()
    {
        PlayerMove();

        RotateVectorUpdate();

        PlayerRotate();
    }

    void PlayerMove()
    {

        float verticalMovement = Input.GetAxis("Vertical");
        float horizontalMovement = Input.GetAxis("Horizontal");

        Vector3 verticalVector = new Vector3(transform.forward.x, 0f, transform.forward.z) * verticalMovement;
        Vector3 horizontalVector = new Vector3(transform.right.x, 0f, transform.right.z) * horizontalMovement;

        transform.position += (verticalVector + horizontalVector) * Time.deltaTime * moveSpeed;
    }

    void RotateVectorUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        RotateVector = new Vector3(Mathf.Clamp(RotateVector.x - mouseY * mouseSensivity, -rotateLimitX, rotateLimitX), RotateVector.y + mouseX * mouseSensivity, 0);
        //RotateVector = new Vector3(RotateVector.x - mouseY * mouseSensivity, RotateVector.y + mouseX * mouseSensivity, 0);
    }
    void PlayerRotate()
    {
        transform.rotation = Quaternion.Euler(0f, RotateVector.y, 0f);
    }
}