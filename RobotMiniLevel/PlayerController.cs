using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10000f;
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;

    void Update()
    {
        // Use WASD for movement input only
        movement.x = Input.GetAxisRaw("Horizontal"); // Only responds to A/D
        movement.y = Input.GetAxisRaw("Vertical");   // Only responds to W/S

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        Shooting shooting = GetComponent<Shooting>();

        if (shooting != null)  // Check if Shooting component exists
        {
            // Set shooting direction based on arrow key input
            if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow))
                shooting.SetMoveDirection(Shooting.MoveDirection.UpRight);
            else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow))
                shooting.SetMoveDirection(Shooting.MoveDirection.UpLeft);
            else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))
                shooting.SetMoveDirection(Shooting.MoveDirection.DownRight);
            else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow))
                shooting.SetMoveDirection(Shooting.MoveDirection.DownLeft);
            else if (Input.GetKey(KeyCode.UpArrow))
                shooting.SetMoveDirection(Shooting.MoveDirection.Up);
            else if (Input.GetKey(KeyCode.DownArrow))
                shooting.SetMoveDirection(Shooting.MoveDirection.Down);
            else if (Input.GetKey(KeyCode.LeftArrow))
                shooting.SetMoveDirection(Shooting.MoveDirection.Left);
            else if (Input.GetKey(KeyCode.RightArrow))
                shooting.SetMoveDirection(Shooting.MoveDirection.Right);
            else
                shooting.SetMoveDirection(Shooting.MoveDirection.None);  // No shooting
        }
    }

    void FixedUpdate()
    {
        // Apply movement with WASD only
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
