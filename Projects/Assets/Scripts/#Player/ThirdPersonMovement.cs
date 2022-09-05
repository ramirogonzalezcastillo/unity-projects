using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public float jumpSpeed = 15f;
    Vector3 velocity;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public Transform cam;
    [SerializeField]
    float speed;
    [SerializeField]
    float turnSmoothTime = 0.1f;
    [SerializeField]
    float turnSmoothSpeed;
    [SerializeField]
    Animator playerAnimator;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2;
            playerAnimator.SetBool("jumping", false);
        }
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothSpeed, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 16f;
                controller.Move(moveDirection.normalized * speed * Time.deltaTime);
                playerAnimator.SetBool("running", true);
            }
            else
            {
                speed = 5f;
                controller.Move(moveDirection.normalized * speed * Time.deltaTime);
                playerAnimator.SetBool("walking", true);
                playerAnimator.SetBool("running", false);
            }
        }
        else {
            playerAnimator.SetBool("walking", false);
            playerAnimator.SetBool("running", false);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        if(!isGrounded)
        {
            playerAnimator.SetBool("walking", false);
            playerAnimator.SetBool("running", false);
            playerAnimator.SetBool("jumping", true);
        }
    }
}