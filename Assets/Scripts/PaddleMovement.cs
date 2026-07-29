using UnityEngine;

public class PaddleMovement : MonoBehaviour
{

    //Speed to inspactor main assign karne ka liye SerializeField ka use karte haa 
    //Speed variable hum ne speed dene ka liye baya haa
    [SerializeField] private float speed = 5f;
    //Paddle ka Rigidbody2D lene ka ref lene ka liye hum ne yaa variable banya haa
    private Rigidbody2D rb;
    //Yaa direction or distance dono deta haa but hume direction chaye jo kay hum
    //normalize ka zarye is ka sirf direction legay length or distance nahi 
    //private Vector2 direction;

    //hum log moible ane wali direcrton or keyobrd say ane wali direction ko alag alag variable  main store karegay

    private Vector2 keyboardDirection;
    private Vector2 mobileDirection;

    //Start Position Per Lejana Paddle ko
    private Vector2 startPosition;
    //Kiya player move kar sekhhay yaa nahi
    private bool canMove;

    public static PaddleMovement instance;

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
        //hum ne Rigidbody2D ka ref awake main set kiya haa yaa script kay load hote hi ref dedega Rigidbody2D ka
        rb = GetComponent<Rigidbody2D>();

        //rb.position say start position lena
    }

    private void Start()
    {
        startPosition = rb.position;

    }


    void Update()
    {
        //agar abhi movement allowed nahi haa toh use rook do

        if (!canMove)
        {
            keyboardDirection = Vector2.zero;
            mobileDirection = Vector2.zero;
            return;
        }
        ;

        //hum ne Input Keys le ha Keycode w uparrow s down arrow take kay jab bhi
        //Player un buttons per click kare toh direction change hojaye or humene
        //Vector2.up Vector.down is liye use kiya haa take normalize de hume
        //Normalize Vector ki length ko 1 kardta haa chaye Vector (1,1) hoo yaa (2,2)
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            keyboardDirection = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            keyboardDirection = Vector2.down;
        }
        else
        {
            keyboardDirection = Vector2.zero;
        }
    }

    void FixedUpdate()
    {
        LanuchPaddle();
    }

   public void LanuchPaddle()
    {

        //agar abhi movement allowed nahi haa toh use rook do
        if (!canMove) return;

        Vector2 finalDirection = Vector2.zero;

    if(keyboardDirection != Vector2.zero)
        {
            finalDirection = keyboardDirection;
        }
    if(mobileDirection != Vector2.zero)
        {
            finalDirection = mobileDirection;
        }

        //Naya direction set karne kay liye hum ne ya variable banya haa
        Vector2 newPosition = rb.position + finalDirection * speed * Time.fixedDeltaTime;
        //Paddle ko screen say bhair jane say roknay ka liye agar y = 4f say zyda hoo
        //To paddle ki y value ko 4f kardo agar kaam ho toh -4f kardo

        //Ya phela or bada traiqa haa
        //if(newPosition.y > 4f)
        //{
        //    newPosition.y = 4f;
        //}
        //if(newPosition.y < -4f){
        //    newPosition.y = -4f;
        //}

        //Ya dosra or sahi traiqa haa jo ke chota bhi haa is mai hum Mathf.Clamp method
        //Ka use karegay min or max set karne ka liye

        newPosition.y = Mathf.Clamp(newPosition.y, -4f, 4f);


        //Yaha hun Paddle ki position set karhe haa yaa tranform.position jeas haa 
        //Magar ya physics ka sath kaam karta haa or hume is ki hi zaroriat haa
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

    public void SetMobileDirection(Vector2 newDirection)
    {
        mobileDirection = newDirection;
    }

}
