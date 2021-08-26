using UnityEngine;

public class Enemies : MonoBehaviour
{
    [Header("General")]
    public float health = 100f;

    public GameObject enemiesController;

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
        //var enemyC = enemiesController.GetComponent<EnemiesController>();
        //Debug.Log("enemyAlived = " + enemyC.enemiesAlived);
        //Debug.Log("enemiesController = " + enemyC);
        //enemyC.enemiesAlived--;  
        Destroy(gameObject);
    }
}
