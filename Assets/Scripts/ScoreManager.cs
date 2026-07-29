using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int leftPlayerScore;
    private int rightPlayerScore;
    [SerializeField] private int winScore = 10;

    public static ScoreManager instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddLeftScore(int score)
    {
        leftPlayerScore += score;

        UIManager.instance.UpdateLeftPaddleText(leftPlayerScore.ToString());

        if (leftPlayerScore >= winScore)
        {
            Debug.Log("Yes player win ka conditon ttrue");

            GameManager.instance.GameOver("You Win", leftPlayerScore);
        }
    }

    public void AddRightScore(int score)
    {
        rightPlayerScore += score;

        UIManager.instance.UpdateRightPaddleText(rightPlayerScore.ToString());

        if(rightPlayerScore >= winScore)
        {
            Debug.Log("Yes computer win ka conditon ttrue");
            GameManager.instance.GameOver("Computer Win", rightPlayerScore);
        }
    }

    public void ResetScore()
    {
        leftPlayerScore = 0;
        rightPlayerScore = 0;
        UIManager.instance.UpdateLeftPaddleText("0");
        UIManager.instance.UpdateRightPaddleText("0");
    }
}
