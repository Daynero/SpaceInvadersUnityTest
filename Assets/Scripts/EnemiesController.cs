using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    [Header("Invaders")]
    public GameObject[] prefabs;
    public AnimationCurve speed;
    public float MissileAttackRate = 1f;
    public GameObject missilePrefab;
   

    [Header("Grid")]
    public int rows = 5;
    public int colums = 11;
    public float columsDistance = 4f;

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
                var position = rowPosition;
                position.x += col * columsDistance;
                enemies.transform.position = position;
            }
        }
    }

    private void Start()
    {
        InvokeRepeating(nameof(MissileAttack), this.MissileAttackRate, this.MissileAttackRate);
    }

    private void Update()
    {
        MoveEnemies();
    }

   

    private void MoveEnemies()
    {
        this.transform.position += _direction * this.speed.Evaluate(GameController.percentKilled) * Time.deltaTime;

        foreach (Transform enemies in this.transform)
        {
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

    private void MissileAttack()
    {
        foreach (Transform enemies in this.transform)
        {
            if (Random.value < (1f / (float)GameController.amountAlive))
            {
                if (enemies.GetComponent<Enemies>().readyAttack)
                {
                    Instantiate(this.missilePrefab, enemies.position, Quaternion.identity);
                    break;
                }
            }
        }
    }

    
}
