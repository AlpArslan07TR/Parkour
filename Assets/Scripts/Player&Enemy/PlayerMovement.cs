using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //Movement
    private CharacterController controller;
    public float speed = 1f;

    //CameraController
    public float mousesens;
    private float xRotation = 0f;

    //Jump And Gravity
    private Vector3 velocity;
    private float gravity = -9.81f;
    private bool isGround;
    public float jumpheight = 0.1f;
    public float gravityDivide = 10f;
    public float jumpSpeed = 30;
    private float aTimer;

    public Transform groundChecker;
    public float groundCheckerRadius;
    public LayerMask obstacle_layer;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //Check is grounded
        isGround = Physics.CheckSphere(groundChecker.position, groundCheckerRadius, obstacle_layer);

        Vector3 moveInputs = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;
        Vector3 moveVelocity = moveInputs * Time.deltaTime * speed;

        controller.Move(moveVelocity);

        //CameraController
        transform.Rotate(0, Input.GetAxis("Mouse X")*Time.deltaTime * mousesens, 0 );
        xRotation -= Input.GetAxis("Mouse Y") * Time.deltaTime * mousesens;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        Camera.main.transform.localRotation =Quaternion.Euler(xRotation, 0,0);
        
        

        //Jump and Gravity
        if (!isGround)
        {
            velocity.y += gravity * Time.deltaTime / gravityDivide;
            aTimer += Time.deltaTime;
            speed = Mathf.Lerp(10,jumpSpeed,aTimer);
        }
        else
        {
            velocity.y = -0.05f;
            speed = 10;
            aTimer = 0;
        }
        if(Input.GetKeyDown(KeyCode.Space)&& isGround)
        {
            velocity.y = Mathf.Sqrt(jumpheight* -2f * gravity / gravityDivide*Time.deltaTime);
        }
        

        controller.Move(velocity);
    }
}
