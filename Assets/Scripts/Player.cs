using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("General")]
    public float speed = 5f;
    public float health = 100f;

    [Header("Use Laser")]
    public GameObject laserPrefab;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position += Vector3.left * this.speed * Time.deltaTime;
        } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += Vector3.right * this.speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space) && fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    private void Shoot()
    {
        var bulletGO = (GameObject)Instantiate(laserPrefab, this.transform.position, Quaternion.identity);
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
