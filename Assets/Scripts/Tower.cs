using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float fireRate = 1.0f;
    public int damage = 1;
    public GameObject projectilePrefab;
    private float fireCooldown;
    private List<Enemy> enemiesInRange = new List<Enemy>();

    private void Update()
    {
        fireCooldown -= Time.deltaTime;
        if (fireCooldown <= 0.0f && enemiesInRange.Count > 0)
        {
            Shoot(enemiesInRange[0]);
            fireCooldown = 1.0f / fireRate;
        }
    }

    private void Shoot(Enemy target)
    {
        GameObject proj = Instantiate(projectilePrefab, transform.Find("FirePoint").position, Quaternion.identity);
        proj.GetComponent<Projectile>().Init(target, damage);
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null && !enemiesInRange.Contains(enemy))
        {
            enemiesInRange.Add(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemiesInRange.Remove(enemy);
        }
    }
}
