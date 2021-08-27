using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text scoreText;
    public static int enemiesAmount = 44;
    public static int enemiesDead = 0;
    public static int amountAlive => enemiesAmount - enemiesDead;
    public static float percentKilled => (float)enemiesDead / (float)enemiesAmount;

    private void Update()
    {
        scoreText.text = "Score: " + PlayerStats.Score.ToString(); ;
    }
}
