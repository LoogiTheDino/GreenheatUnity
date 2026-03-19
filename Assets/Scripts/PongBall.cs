using System.Collections;
using UnityEngine;

public class PongBall : MonoBehaviour
{
    Rigidbody2D rb;

    public float startingSpeed = 4f;
    public float startingDelay = 1f;
    public float resetDelay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(StartDelay(startingDelay));
    }

    public void FreezeBall()
    {
        rb.linearVelocity = Vector2.zero;
    }

    public void ResetPosition()
    {
        transform.position = Vector2.zero;
    }

    public void ResetBall()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = Vector2.zero;
        StartCoroutine(StartDelay(resetDelay));
    }

    public void MoveBall()
    {
        bool isRight = UnityEngine.Random.value >= 0.5;

        float xVelocity = -1f;
        if (isRight == true) xVelocity = 1f;

        float yVelocity = UnityEngine.Random.Range(-1f, 1f);

        rb.linearVelocity = new Vector2(xVelocity * startingSpeed, yVelocity * startingSpeed);
    }

    IEnumerator StartDelay (float delay)
    {
        yield return new WaitForSeconds(delay);
        MoveBall();
    }
}
