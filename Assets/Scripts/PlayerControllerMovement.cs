using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerMovement : MonoBehaviour
{
    public float speed = 5;
    private Vector2 movementInput;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.TriggerGoalReached();  
        }
    }
    public void OnMovement(InputAction.CallbackContext context) 
    {
        movementInput = context.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementInput.x, 0, movementInput.y) * speed;

        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }
}
/*{
    public float speed = 5;
private Vector2 movementInput;
private Rigidbody rb;
public SOstats stats;

private float currentHealth;
private float currentDamage;

private void Awake()
{
    rb = GetComponent<Rigidbody>();

    if (stats != null)
    {
        currentHealth = stats.health;
        currentDamage = stats.damage;
    }
    else
    {
        Debug.LogWarning("Stats not assigned!");
    }
}

private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        GameManager.Instance.TriggerGoalReached();
    }
}

public void OnMovement(InputAction.CallbackContext context)
{
    movementInput = context.ReadValue<Vector2>();
}

void FixedUpdate()
{
    Vector3 movement = new Vector3(movementInput.x, 0, movementInput.y) * speed;
    rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
}

public void TakeDamage(float damage)
{
    currentHealth -= damage;
    if (currentHealth <= 0)
    {
        Debug.Log("Player is dead");
    }
}
}*/