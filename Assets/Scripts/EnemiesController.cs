using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject[] prefabs;

    public AnimationCurve speed;

    public int rows = 5;

    public int colums = 11;

    public float columsDistance = 4f;

    public int amountKilled { get; private set; }

    public int totalEnemies => this.rows * this.colums;

    public float percentKilled => (float)this.amountKilled / (float)this.totalEnemies;

    public Vector3 rightEdge = new Vector3(32, 2, -18);

    public Vector3 leftEdge = new Vector3(-37, 2, -18);

    private Vector3 _direction = Vector2.right;

    private void Awake()
    {
        for (int row = 0; row < this.rows; row++)
        {
            var width = columsDistance * (this.colums - 1);
            var height = columsDistance * (this.rows - 1);
            var centering = new Vector2(-width / 2, -height / 2);
            var rowPosition = new Vector3(centering.x, centering.y + (row * columsDistance), 24f);

            for (int col = 0; col < this.colums; col++)
            {
                var enemies = Instantiate(this.prefabs[row], this.transform);
                //enemiesAlived++;
                var position = rowPosition;
                position.x += col * columsDistance;
                enemies.transform.position = position;
            }
        }
    }

    private void Update()
    {
       // Debug.Log("Enemies Alliwed Start " + enemiesAlived);

        this.transform.position += _direction * this.speed.Evaluate(this.percentKilled) * Time.deltaTime;

        foreach (Transform enemies in this.transform)
        {
            if (!enemies.gameObject.activeInHierarchy)
            {
                continue;
            }

            if (_direction == Vector3.right && enemies.position.x >= rightEdge.x)
            {
                AdvanceRow();
            }
            else if (_direction == Vector3.left && enemies.position.x <= leftEdge.x + 1f)
            {
                AdvanceRow();
            }
        }
    }

    private void AdvanceRow()
    {
        _direction.x *= -1.0f;

        var position = this.transform.position;
        position.y -= 1f;
        this.transform.position = position;
    }

    
}
