using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 50f;
    public int damage = 5;

    private void Update()
    {
        var distanceThisFrame = speed * Time.deltaTime;

        transform.Translate(new Vector3(0, distanceThisFrame, 0), Space.World);

        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);

        if (other.gameObject.CompareTag("Enemy"))
        {
            Damage(other.transform);
        }
    }

    private void Damage(Transform enemy)
    {
        var e = enemy.GetComponent<Enemies>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }
}
