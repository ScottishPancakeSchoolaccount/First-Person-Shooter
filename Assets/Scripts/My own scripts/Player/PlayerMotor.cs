using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool IsGrounded;
    public float walkingSpeed = 5f; //f is for floats
    public float runningSpeed = 15f; // speed of the player
    public float speed;
    public float gravity = -9.8f;
    public float jumpHeight = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        IsGrounded = controller.isGrounded;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runningSpeed;
        }
        else
        {
            speed = walkingSpeed;
        }
    }
    //Recieve the inputs for our Intput managaer.cs and apply then to out Character Controller
    public void ProcessMove(Vector3 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection)* speed *Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if (IsGrounded && playerVelocity.y <0)
            playerVelocity.y = -2f;
        controller.Move(playerVelocity * Time.deltaTime);
        Debug.Log(playerVelocity.y);
    }
    public void Jump()
    {
        if (IsGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }
}
