using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed; // Speed of the projectile

    private Vector3 targetPosition;

    private void Start()
    {
        // Find the player and get their position
        PlayerController player = FindObjectOfType<PlayerController>();
        if (player != null)
        {
            targetPosition = player.transform.position;
        }
        else
        {
            Destroy(gameObject); // Destroy projectile if no player is found
        }
    }

    private void Update()
    {
        // Move the projectile toward the player's initial position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if (transform.position == targetPosition)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}