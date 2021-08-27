using UnityEngine;

public class Enemies : MonoBehaviour
{
    [Header("General")]
    public float health = 100f;
    public int scoreCost = 10;
    public bool readyAttack = false;

    public System.Action killed;

    private void Update()
    {
        CheckMissileCollision();
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
        PlayerStats.Score += scoreCost;

        GameController.enemiesDead++;

        Destroy(gameObject);
    }

    private void CheckMissileCollision()
    {
        var fwd = transform.TransformDirection(new Vector3(0, -9999, 0));

        readyAttack = (Physics.Raycast(transform.position, fwd, 20)) ? false : true;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position,new Vector3(0,-9999,0));
    }
}
