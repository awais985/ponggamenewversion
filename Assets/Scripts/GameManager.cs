using UnityEngine;

public class GameManager : MonoBehaviour
{
    // mene do panel ka ref lene ha inspactor main is liye yaa banye haa
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject mainMenuPanel;
    //yaa check karha haa kay abhi gameover to nahi hogaya
    private bool isGameOver;

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    //PlayerScored method agar left player nay gol kiya toh us ko warna right wale ko score derha haa agar left
    //Wale gol main gaya toh right wala jete gaa agar right wale main ga
    public void PlayerScored(bool leftPlayerScored)
    {
        if (leftPlayerScored)
        {
            ScoreManager.instance.AddLeftScore(1);
        }

        if (!leftPlayerScored)
        {
            ScoreManager.instance.AddRightScore(1);
        }
        BallMovement.instance.ResetBallPosition();
    }


    //GameOver Method isGameOver ko true take pata chal jaye isGameOver howa haa ya anho or ball ki
    //Movement ko reset ui main score ka text or total score behjh rha haa
    public void GameOver(string winnerText,int totalScore)
    {
        isGameOver = true;
        gameOverPanel.SetActive(true);
        UIManager.instance.UpdateGameOverWinText(winnerText);
        UIManager.instance.UpdateGameOverScoreText(totalScore.ToString());
    }

    //ya tab aye gaa jab hum game start karegay
    public void StartGame()
    {
        isGameOver = false;

        mainMenuPanel.SetActive(false);

        PaddleMovement.instance.StartPaddle();
        EnemyPaddleMovement.instance.StartPaddle();
        BallMovement.instance.LaunchBall();
    }

    //Ya tab kaam aye ga jab hum game ko restart karegay

    public void RestartGame()
    {
        isGameOver = false;
        ResetGame();
        gameOverPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    //ya tab kaam aye gaa jab game ko reset karegay
    public void ResetGame()
    {
        ScoreManager.instance.ResetScore();
        PaddleMovement.instance.ResetPaddle();
        EnemyPaddleMovement.instance.ResetPaddle();
        BallMovement.instance.ResetBallPosition();
    }

    //YAA CHECK KARHA HAA KA GAME OVER HOWA YA ANAHI
    public bool IsGameOver()
    {
        return isGameOver;
    }
}
