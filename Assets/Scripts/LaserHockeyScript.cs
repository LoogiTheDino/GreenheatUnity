using UnityEngine;
using UnityEngine.UI;

public class LaserHockeyScript : MonoBehaviour
{
    int xScale;
    public int yScale = 7;
    public float distanceFromCentre = 5.5f;
    public GameObject ball;
    public int winningScore = 10;

    [Space]
    [Header("Title Screen")]
    public GameObject titleScreen;
    public RectTransform PlayButton;
    public RectTransform QuitButton;

    [Space]
    [Header("Assignment Screen")]
    public GameObject assignmentScreenOne;
    public GameObject assignmentScreenTwo;
    public RectTransform AssignPlayerOne;
    public RectTransform AssignPlayerTwo;
    public Text alreadyText1;
    public Text alreadyText2;
    bool player1assigned = false;
    bool player2assigned = false;

    [Space]
    [Header("Play Screen")]
    public GameObject gameScreenUI;
    public GameObject gameScreen;

    [Space]
    [Header("Player 1 - Left")]
    public GameObject Paddle1;
    public Text scoreDisplay1;
    Vector2 paddle1Position;
    string id1;
    public int score1;

    [Space]
    [Header("Player 2 - Right")]
    public GameObject Paddle2;
    public Text scoreDisplay2;
    Vector2 paddle2Position;
    string id2;
    public int score2;

    [Space]
    [Header("Winning Screen")]
    public GameObject WinScreen;
    public Text WinningText;
    bool matchOver;
    public RectTransform TitleScreenButton;

    public bool isMatchOver()
    {
        return matchOver;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        xScale = yScale * (16 / 9);
        titleScreen.SetActive(true);

        ObjectDirectory.Instance.AddToList(PlayButton);
        ObjectDirectory.Instance.AddToList(QuitButton);
    }

    // Update is called once per frame
    void Update()
    {
        GreenHeatEventManager.OnGreenHeatHover += MovePaddle;
        GreenHeatEventManager.OnGreenHeatDrag += MovePaddle;

        Paddle1.transform.position = paddle1Position;
        Paddle2.transform.position = paddle2Position;
    }

    public void QuitApp()
    {
        ObjectDirectory.Instance.adminSettings.ClosePongApp();
    }

    public void PlayGame()
    {
        ObjectDirectory.Instance.RemoveFromList(PlayButton);
        ObjectDirectory.Instance.RemoveFromList(QuitButton);
        titleScreen.SetActive(false);

        assignmentScreenOne.SetActive(true);
        assignmentScreenTwo.SetActive(true);
        ObjectDirectory.Instance.AddToList(AssignPlayerOne);
        ObjectDirectory.Instance.AddToList(AssignPlayerTwo);
    }

    public void AssignPlayer1(string id)
    {
        if (id2 != id)
        {
            ObjectDirectory.Instance.RemoveFromList(AssignPlayerOne);
            assignmentScreenOne.SetActive(false);
            Paddle1.SetActive(true);
            id1 = id;
            player1assigned = true;

            paddle1Position = new Vector2(-distanceFromCentre, 0f);

            alreadyText1.gameObject.SetActive(false);

            if (player2assigned == true) StartGame();
        }
        else
        {
            alreadyText1.text = "You're already playing " + id + "!";
            alreadyText1.gameObject.SetActive(true);
        }
    }

    public void AssignPlayer2(string id)
    {
        if (id1 != id)
        {
            ObjectDirectory.Instance.RemoveFromList(AssignPlayerTwo);
            assignmentScreenTwo.SetActive(false);
            Paddle2.SetActive(true);
            id2 = id;
            player2assigned = true;

            paddle2Position = new Vector2(distanceFromCentre, 0f);

            alreadyText2.gameObject.SetActive(false);

            if (player1assigned == true) StartGame();
        }
        else
        {
            alreadyText2.text = "You're already playing " + id + "!";
            alreadyText2.gameObject.SetActive(true);
        }
    }

    public void StartGame()
    {
        score1 = 0;
        score2 = 0;
        scoreDisplay1.text = score1.ToString();
        scoreDisplay2.text = score2.ToString();

        gameScreenUI.SetActive(true);
        ball.SetActive(true);
        ball.GetComponent<PongBall>().ResetBall();
    }

    public void MovePaddle(GreenHeatMessage message)
    {
        if (message.id == id1) paddle1Position = new Vector2(-message.x * xScale, -(message.y - 0.5f) * yScale);
        else if (message.id == id2) paddle2Position = new Vector2(message.x * xScale, -(message.y - 0.5f) * yScale);
    }

    public void AddPoints(bool onRightSide)
    {
        if (onRightSide)
        {
            score1++;
            scoreDisplay1.text = score1.ToString();
        }
        else
        {
            score2++;
            scoreDisplay2.text = score2.ToString();
        }

        if (score1 == winningScore || score2 == winningScore)
        {
            FinishGame();
        }
    }

    public void FinishGame()
    {
        matchOver = true;
        ball.GetComponent<PongBall>().FreezeBall();
        if (score1 == winningScore) WinningText.text = id1 + " wins!";
        else if (score2 == winningScore) WinningText.text = id2 + " wins!";

        WinScreen.gameObject.SetActive(true);
        ObjectDirectory.Instance.AddToList(TitleScreenButton);
        ObjectDirectory.Instance.ShowAllCursors();
    }

    public void BackToTitleScreen()
    {
        ObjectDirectory.Instance.RemoveFromList(TitleScreenButton);

        WinScreen.SetActive(false);
        gameScreenUI.SetActive(false);

        id1 = null;
        id2 = null;
        player1assigned = false;
        player2assigned = false;

        ball.SetActive(false);
        Paddle1.SetActive(false);
        Paddle2.SetActive(false);
        Start();
    }
}
