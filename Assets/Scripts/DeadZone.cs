using UnityEngine;

public class DeadZone : MonoBehaviour
{
    //Sab say phele yaa check karna hoga ball kis player ka gol main gai us ka liye
    //Ek variable bana hoga isleftzone ka naam say bool main SerializeField ka sath
    //Take ya check kar sekhay kay inspactor main left mai gai yaa right main
    [SerializeField] private bool isLeftZone;
    //Ab hume scoremanager ka ref chaye take hum waha say IncreaseLeftPaddleScore or
    //IncreaseRightPaddleScore kay kis ne gol kiya haa abhi
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Ab hum check kare gay jo object is deadzone say taqraya haa kiya us ka tag ball haa
        //Agar haa toh phir jis player ka ya deadzone haa us ko gol do or agar game over nahi
        //Howa toh ball again LaunchBall method call kardo warna win ki screen show kardo
        if (collision.CompareTag("Ball"))
        {
            GameManager.instance.PlayerScored(!isLeftZone);
            bool isGameOver = GameManager.instance.IsGameOver();
            if (!isGameOver)
            {
                BallMovement.instance.LaunchBall();
            }
        }
    }
}
