using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerSalto : MonoBehaviour
{
    public float speed = 5;
    public float jumpForce = 5;
    private Vector2 movementInput;
    private Rigidbody rb;

    private bool isGrounded;
    private int jumpCount = 0;
    public LayerMask groundLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && (isGrounded || jumpCount < 2))
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            jumpCount++;
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementInput.x, 0, movementInput.y) * speed;

        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);

        CheckGroundStatus();
    }

    void CheckGroundStatus()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1f, groundLayer);
        if (isGrounded)
        {
            jumpCount = 0;
        }
    }
}