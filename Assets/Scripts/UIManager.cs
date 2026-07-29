using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UIManager : MonoBehaviour
{
    //Hum logo nay 2 text add kiye game object phir un kay ref liye haa yaha take screen per
    //Hum log dekha sake kis player kitne score howay haa abhi tak
    [SerializeField] private TextMeshProUGUI leftPaddleText;
    [SerializeField] private TextMeshProUGUI rightPaddleText;
    //Ab hume gameover panel ka text bhi chaye take hum us per show kar sekae kon sa player jita
    [SerializeField] private TextMeshProUGUI whichPlayerWinText;
    //Ab hume score bhi update karna hoga jo gameoverpanel main arha haa
    [SerializeField] private TextMeshProUGUI gameoverPanelSoreText;
    //Hum logo nay ek signleton use kiya take ek object ka ek hi instance bane dosra destory 
    //Hojaye awake main kiya haa us ka logic
    public static UIManager instance;

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
    //UpdateLeftPaddleText method left paddle ka score dekhata haa
    public void UpdateLeftPaddleText(string score)
    {
        leftPaddleText.text = score;
    }
    //UpdateRightPaddleText Right Player ka score dekhata ha
    public void UpdateRightPaddleText(string score)
    {
        rightPaddleText.text = score;

    }

    public void UpdateGameOverWinText(string winnerName)
    {
        whichPlayerWinText.text = winnerName;
    }

    public void UpdateGameOverScoreText(string score)
    {
        gameoverPanelSoreText.text = score;
    }
}
