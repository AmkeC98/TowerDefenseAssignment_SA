using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5.0f;
    public int health = 5;
    private Transform[] waypoints;
    private int waypointIndex = 0;

    public void Init(Transform[] pathPoints)
    {
        waypoints = pathPoints;
    }

    private void Update()
    {
        if (waypoints == null || waypointIndex >= waypoints.Length) return;

        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, waypoints[waypointIndex].position) < 0.1f)
        {
            waypointIndex++;

            if (waypointIndex >= waypoints.Length)
            {
                ReachBase();
            }
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void ReachBase()
    {
        FindObjectOfType<BaseHealth>().TakeDamage(1);
        Destroy(gameObject);
    }
}
