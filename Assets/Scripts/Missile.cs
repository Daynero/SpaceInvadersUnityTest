using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed = 50f;
    public int damage = 100;

    public System.Action destroyed;

    private void Update()
    {
        var distanceThisFrame = speed * Time.deltaTime;

        transform.Translate(new Vector3(0, -distanceThisFrame, 0), Space.World);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);

            if (other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("Player"))
            {
                Damage(other.transform);
            }
        }
    }

    private void Damage(Transform enemy)
    {
        var wall = enemy.GetComponent<Wall>();
        var player = enemy.GetComponent<Player>();

        if (wall != null)
        {
            wall.TakeDamage(damage);
        } else if (player != null)
        {
            player.TakeDamage(damage);
        }
    }
}
