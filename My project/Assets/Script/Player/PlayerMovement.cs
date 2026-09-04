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

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");// 水平方向の入力を取得

        Vector3 velocity = rb.linearVelocity;//rb(Rigidbodyが持っている速度を取得)
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

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumppower, ForceMode.Impulse);
        }
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
