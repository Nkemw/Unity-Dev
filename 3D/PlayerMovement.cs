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

    [SerializeField] float runRatio = 1.2f;


    [SerializeField] float jumpForce = 10f;

    Rigidbody rigidbody;

    bool isGrounded;
    private void Start()
    {
        RotateVector = transform.forward;
        rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        PlayerMove();

        if (IsJump())
        {
            PlayerJump();
        }
        

        RotateVectorUpdate();

        PlayerRotate();
    }

    void PlayerMove()
    {

        float verticalMovement = Input.GetAxis("Vertical");
        float horizontalMovement = Input.GetAxis("Horizontal");

        Vector3 verticalVector = new Vector3(transform.forward.x, 0f, transform.forward.z) * verticalMovement;
        Vector3 horizontalVector = new Vector3(transform.right.x, 0f, transform.right.z) * horizontalMovement;

        Vector3 moveVector = (verticalVector + horizontalVector).normalized * Time.deltaTime * moveSpeed;

        if (IsRun(verticalMovement))
        {
            transform.position += moveVector * runRatio;
        } else
        {
            transform.position += moveVector;
        }
    }

    void RotateVectorUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        RotateVector = new Vector3(Mathf.Clamp(RotateVector.x - mouseY * mouseSensivity, -rotateLimitX, rotateLimitX), RotateVector.y + mouseX * mouseSensivity, 0);
    }
    void PlayerRotate()
    {
        transform.rotation = Quaternion.Euler(0f, RotateVector.y, 0f);
    }

    bool IsRun(float verticalMovement)
    {
        if (Input.GetKey(KeyCode.LeftShift) && verticalMovement > 0f)
        {
            return true;
        }
        return false;
    }

    bool IsJump()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            return true;
        }
        return false;
    }
    void PlayerJump()
    {
        rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}