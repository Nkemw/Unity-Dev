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

    //int layerMask;
    private void Start()
    {
        transform.rotation = Quaternion.Euler(cameraRot);

        offset = transform.position - playerPos.position;

        //layerMask = 1 << LayerMask.NameToLayer("Raycastable");        
    }
    void FixedUpdate()
    {
        
        CameraRotate();
        CameraMove();
        
    }

    
    void CameraMove()
    {
        Vector3 targetPosition = playerPos.position - transform.forward * offset.magnitude;
        
        RaycastHit hit;

        int layerMask = 1 << LayerMask.NameToLayer("Raycastable");

        if (Physics.Raycast(playerPos.position, -transform.forward, out hit, offset.magnitude, layerMask))
        {
            transform.position = Vector3.Slerp(transform.position, hit.point, softness);
        }
        else
        {
            transform.position = Vector3.Slerp(transform.position, targetPosition, softness);
        }
    }

    
    void CameraRotate()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(player.RotateVector), softness);
    }
}