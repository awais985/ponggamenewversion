using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Vector2 startPos;

    private Rigidbody2D rb;

    public static BallMovement instance;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    //void Start()
    //{
    //    //Sab say phele direction nikalna haa kay ball kis traf jana haa uper ya niche
    //    //toh us ka liye ek variable bana hoga jo hume random direction dega uper na 
    //    //nuche ka
    //    LaunchBall();
    //}

    //Ab hume 2 methods bane hogay ek luched wala ek stopped wala 

    public void LaunchBall()
    {
        //hum logo ne disntace liye ha random 0 say lekar 1 tak q k random 2 return nah
        //karega
        int direction = Random.Range(0, 2);
        // rb.position  zero agar phele say koi position ho
        rb.position = Vector2.zero;
        // rb.linearVelocity  zero agar phele say koi linearVelocity ho
        rb.linearVelocity = Vector2.zero;
        //distance ka variable banaya haa humne jis main agar direction nay
        //randomly 0 diya toh disntace main hum right jaye gay or up agar 1 toh left
        //uper
        Vector2 distance = Vector2.zero;
        if (direction == 0)
        {
            distance = new Vector2(1, 1);
        }
        if (direction == 1)
        {
            distance = new Vector2(1, -1);
        }
        //hum logo ne linearVelocity set kar di yaa 
        rb.linearVelocity = distance * speed;
    }

    public void ResetBallPosition()
    {
        rb.linearVelocity = Vector2.zero;
        rb.position = Vector2.zero;
    }

}
