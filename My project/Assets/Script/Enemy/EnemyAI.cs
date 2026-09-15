using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;

    public float MoveSpeed = 3f;    //敵の移動速度
    public float attackRangeX = 1.5f;//攻撃範囲
    public float attackRangeY = 1.0f;//攻撃範囲

    public int attackDamage = 10;   //攻撃力
    public float attackCooldown = 2f;//攻撃のクールダウン時間

    public float warningTime = 0.6f;//攻撃前の警告時間
    public float recoveryTime = 1.0f;//攻撃後の回復時間

    public GameObject attackingWarning;//攻撃前の警告のオブジェクト

    private float lastAttackTime;//最後に攻撃した時間
    private float stateTimer;//状態のタイマー

    private int facingDirection = 1;//敵の向き（1:右, -1:左）

    /**
     * レーン移動の設定
     */ 
    public float laneDistance = 2f; // レーンの距離
    public float laneMoveSpeed = 8f; // レーン移動の速度
    public float laneTolerance = 0.1f; // レーン移動の許容範囲

    //敵の状態を管理する列挙型
    private enum  EnemyState
    {
        Move,
        Warning,
        Attack,
        Recovery
    }
    private EnemyState currentState;//敵の現在の状態

    void Start()
    {
     if(attackingWarning != null)
        {
            attackingWarning.SetActive(false);
        }
    }
    private void Update()
    {
        
            if (player == null) return;

            UpdateAttackingWarningPosition();
        //現在の状態に応じて処理を分岐
        switch (currentState)
        {
            case EnemyState.Move:
                UpdateMove();
                break;

            case EnemyState.Warning:
                UpdateWarning();
                break;
                
            case EnemyState.Attack:
                UpdateAttack();
                break;

            case EnemyState.Recovery:
                UpdateRecovery();
                break;
        }
    }

    void UpdateMove()
    {
        //プレイヤーの位置に応じて敵のZ座標を調整
        float targetZ = GetNearestLaneZ(player.position.z);

        float newZ = Mathf.MoveTowards(
            transform.position.z,
            targetZ,
            laneMoveSpeed * Time.deltaTime
            );

        transform.position = new Vector3(
            transform.position.x,
            transform.position.y,
            newZ
            );

        //同じレーンにいるかどうかを確認

        bool sameLane = 
            Mathf.Abs(transform.position.z - targetZ) <= laneTolerance;

        //違うレーンなら,攻撃しない
        if (!sameLane) return;

        //プレイヤーと敵の距離を計算
        float distanceX =
            Mathf.Abs(player.position.x - transform.position.x);

        float distanceY = 
                        Mathf.Abs(player.position.y - transform.position.y);


        //プレイヤーの位置を見て敵を攻撃警告状態にする
        if (distanceX <= attackRangeX && distanceY <= attackRangeY)
        {
            currentState = EnemyState.Warning;
            stateTimer = warningTime;

            //攻撃警告のオブジェクトを有効化
            if (attackingWarning != null)
            {
                attackingWarning.SetActive(true);
            }
            Debug.Log("Enemy Warning");

            return;

        }

        float direction = 
            Mathf.Sign(player.position.x-transform.position.x);

        facingDirection = direction > 0 ? 1 : -1;

        transform.position += 
            Vector3.right *
            direction *
            MoveSpeed *
            Time.deltaTime;
    }

    private void UpdateWarning()
    {
        //状態の変化の時間を減らす
        stateTimer -= Time.deltaTime;

        if(stateTimer <= 0)
        {
            if(attackingWarning != null)
            {
                attackingWarning.SetActive(false);
            }
            currentState = EnemyState.Attack;//攻撃状態に遷移
        }
    }

    void UpdateAttack()
    {
        float distanceX =
            Mathf.Abs(player.position.x - transform.position.x);

        float distanceY =
            Mathf.Abs(player.position.y - transform.position.y);

        float distanceZ =             
            Mathf.Abs(player.position.z - transform.position.z);
        bool sameLane =
            distanceZ <= laneTolerance;
        if (distanceX <= attackRangeX && distanceY <= attackRangeY && sameLane)
        {
            PlayerHealth health =
                player.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.TakeDamage(attackDamage);
            }
        }
        Debug.Log("Enemy Attack!");
        currentState = EnemyState.Recovery;
        stateTimer = recoveryTime;
    }

    //回復状態の更新
    void UpdateRecovery()
    {
        stateTimer -= Time.deltaTime;
        if (stateTimer <= 0f)
        {
            currentState = EnemyState.Move;
        }
    }

    void UpdateAttackingWarningPosition()
    {
        if ((attackingWarning == null)) return;
        Vector3 localPos = attackingWarning.transform.localPosition;

        localPos.x =
            Mathf.Abs(localPos.x) * facingDirection;
        attackingWarning.transform.localPosition = localPos;

    }

    float GetNearestLaneZ(float targetZ)
    {
        int lane = Mathf.RoundToInt(targetZ / laneDistance); //ターゲットが何番目のレーンにいるかに変換(Roundで少数を一番近い整数に変換)
        lane = Mathf.Clamp(lane, -1, 1);//レーンの範囲を制限(-1:左, 0:中央, 1:右)
        return lane * laneDistance;//レーン番号をz座標に変換
    }

}