using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public float fireRate = 0.5f; // Time between shots in seconds

    private float nextTimeToFire = 0f;
    private MoveDirection currentDirection = MoveDirection.None;

    public enum MoveDirection
    {
        None,
        Right,
        Left,
        Up,
        Down,
        UpRight,
        UpLeft,
        DownRight,
        DownLeft
    }

    void Update()
    {
        // Shoot continuously as long as an arrow key is pressed
        if (currentDirection != MoveDirection.None && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        Vector2 forceDirection = GetForceDirection();
        float angle = GetAngleForDirection();

        bullet.transform.rotation = Quaternion.Euler(0f, 0f, angle);
        rb.AddForce(forceDirection * bulletForce, ForceMode2D.Impulse);
    }

    Vector2 GetForceDirection()
    {
        switch (currentDirection)
        {
            case MoveDirection.Right: return Vector2.right;
            case MoveDirection.Left: return Vector2.left;
            case MoveDirection.Up: return Vector2.up;
            case MoveDirection.Down: return Vector2.down;
            case MoveDirection.UpRight: return new Vector2(1, 1).normalized;
            case MoveDirection.UpLeft: return new Vector2(-1, 1).normalized;
            case MoveDirection.DownRight: return new Vector2(1, -1).normalized;
            case MoveDirection.DownLeft: return new Vector2(-1, -1).normalized;
            default: return Vector2.zero;
        }
    }

    float GetAngleForDirection()
    {
        switch (currentDirection)
        {
            case MoveDirection.Right: return 0f;
            case MoveDirection.Left: return 180f;
            case MoveDirection.Up: return 90f;
            case MoveDirection.Down: return 270f;
            case MoveDirection.UpRight: return 45f;
            case MoveDirection.UpLeft: return 135f;
            case MoveDirection.DownRight: return 315f;
            case MoveDirection.DownLeft: return 225f;
            default: return 0f;
        }
    }

    public void SetMoveDirection(MoveDirection direction)
    {
        currentDirection = direction;
    }
}
