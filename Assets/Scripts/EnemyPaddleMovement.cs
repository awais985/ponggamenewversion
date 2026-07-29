using UnityEngine;

public class EnemyPaddleMovement : MonoBehaviour
{
    //check karo kay ball kha haa
    //use ka hisab say paddle move karo
    //Ball ka ref inpactor main lena is liye SerializeField use kiya haa
    [SerializeField] private Transform ball;
    //Vector say direction lena lekin abhi is main koi value asign nahi haa
    [SerializeField] private Vector2 direction;
    //Speed set ki haa paddle ki 5f
    [SerializeField] private float speed = .5f;
    //Rigidbody2D le haa take movement kar sekhay physics base per
    private Rigidbody2D rb;
    //Start Position Per Lejana Paddle ko
    private Vector2 startPosition;
    //Ab yaa check karna ka paddle move kar sekhtay haa yaa nahi abho
    private bool canMove;

    public static EnemyPaddleMovement instance;

    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        //Current object kay component ssay Rigidbody2D uthana
        rb = GetComponent<Rigidbody2D>();
        
        //rb.position say start position lena
        startPosition = rb.position;
    }

    void Update()
    {
        //ball or paddle kay beach ka different lena ball paddle say kitni dor haa
        float ballDistance = ball.transform.position.y - transform.position.y;
        direction = Vector2.zero;

        //Agar ball 0.5f y ki position ho toh yani ball up haa toh paddle ko uper
        //Bhejo or agar ball ka distance -0.5f say kaam hoo yani agar -0.6 hoo toh 
        //Is toh paddle ko niche bhejo
        if (ballDistance > 0.5f)
        {
            direction = Vector2.up;
        }
        if(ballDistance < -0.5f)
        {
            direction = Vector2.down;
        }

    }

    private void FixedUpdate()
    {
        LaunchPaddle(); 
    }

    //Ab Hum Log Enemy Paddle ka Move Or Stop Method Ready Karegay Take Or Jaga
    //Per Use Hoskay

    public void LaunchPaddle()
    {
        //agar abhi movement allowed nahi haa toh use rook do
        if (!canMove) return;
        //Sab say phele new posotion vector 2 ka variable create karegay take purani
        //Position main new position add ho skay
        Vector2 newPosition = rb.position + direction * speed * Time.fixedDeltaTime;
        //Min or max set karna take enemy ka paddle screen say bhair na jaye limit
        //Hojaye
        newPosition.y = Mathf.Clamp(newPosition.y, -4f, 4f);

        //Ab is ki position set karena ka is position per jaye
        rb.MovePosition(newPosition);
    }

    public void StartPaddle()
    {
        canMove = true;
    }

    public void ResetPaddle()
    {
        rb.position = startPosition;
        canMove = false;
    }

}
