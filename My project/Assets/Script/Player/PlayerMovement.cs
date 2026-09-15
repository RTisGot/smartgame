using UnityEngine;

// <summary>
//プレイヤーの動きを制御するスクリプト
public class PlayerMovement:MonoBehaviour
{
    public float movespeed = 5f;
    public float jumppower = 7f;

    private Rigidbody rb;// Rigidbody2Dコンポーネントを格納する変数
    private bool isGrounded;// プレイヤーが地面に接しているかどうかを判定する変数

    public int facingDirection = 1; // プレイヤーの向きを表す変数（1:右, -1:左）

    public float laneDistance = 2f;
    public float laneMoveSpeed = 8f;

    private int currentLane = 1;// 現在のレーン（0:左, 1:中央, 2:右）

    public bool canMove = true; // プレイヤーが移動できるかどうかを制御するフラグ

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
        if (!canMove)
        {
           
            rb.linearVelocity = Vector3.zero;
            return;
        }
        Vector3 velocity = rb.linearVelocity;//rb(Rigidbodyが持っている速度を取得)
        float horizontal = Input.GetAxisRaw("Horizontal");// 水平方向の入力を取得

        velocity.x = horizontal * movespeed;
        rb.linearVelocity = velocity;

        //右か左かの向きを判定する
        if (horizontal > 0)
        {
            facingDirection = 1;
        }
        else if (horizontal < 0)
        {
            facingDirection = -1;
        }

        //----レーン移動の入力を処理する
        //上に移動
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            currentLane++;
            if(currentLane > 2)
            {
                currentLane = 2;
            }
        }
        //下に移動
        if(Input.GetKeyDown(KeyCode.S) && isGrounded)
        {
            currentLane--;
            if(currentLane < 0)
            {
                currentLane = 0;
            }
        }
        //------
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumppower, ForceMode.Impulse);
            isGrounded = false;
        }

        float targetZ = (currentLane - 1) * laneDistance;
        Vector3 position = transform.position;
        position.z = Mathf.MoveTowards(
            position.z,
            targetZ,
            laneMoveSpeed * Time.deltaTime
            );
        transform.position = position;
    }
    //地面に接しているかどうかを判定する
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
