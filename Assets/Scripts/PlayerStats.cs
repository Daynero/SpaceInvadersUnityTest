using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Lives;
    public static int Score = 0;
    public int startLives = 5;

    private void Start()
    {
        Lives = startLives;
    }
}
