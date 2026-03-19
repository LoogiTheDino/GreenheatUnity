using UnityEngine;

public class PongScorer : MonoBehaviour
{
    public bool onRightSide;
    PongScript pong;
    public PongBall ball;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pong = GetComponentInParent<PongScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        pong.AddPoints(onRightSide);
        if (pong.isMatchOver())
        {
            ball.FreezeBall();
        }
        else
        {
            ball.ResetBall();
        }
    }
}
