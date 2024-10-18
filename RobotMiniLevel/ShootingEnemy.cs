using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public float speed;
    public Transform target;
    public float minimumDistance = 0.5f;
    
    public GameObject projectile;
    public float timeBetweenShots;
    public float nextShotTime;
    
    
// Move toward the player if within range
    private void Update()
    {
        if (Time.time > nextShotTime)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            nextShotTime = Time.time + timeBetweenShots;
        }
        
        if (Vector2.Distance(transform.position, target.position) < minimumDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
        }
    }

}
