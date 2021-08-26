using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public GameObject[] animationObject;

    public float animationTime = 1f;

    private int _animationFrame = 0;

    private void Start()
    {
        InvokeRepeating(nameof(AnimateObject), this.animationTime, this.animationTime);
    }

    private void AnimateObject()
    {
        // Активируем каждый объект по очереди для создания эффекта анимации
        if (animationObject[_animationFrame].activeSelf)
        {
            animationObject[_animationFrame].SetActive(false);
            animationObject[_animationFrame + 1].SetActive(true);
        } else
        {
            animationObject[_animationFrame].SetActive(true);
            animationObject[_animationFrame + 1].SetActive(false);
        }
    }
}
