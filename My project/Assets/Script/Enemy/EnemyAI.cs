using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;

    public float MoveSpeed = 3f;    //“G‚ÌˆÚ“®‘¬“x
    public float attackRange = 1.5f;//UŒ‚”ÍˆÍ

    public int attackDamage = 10;   //UŒ‚—Í
    public float attackCooldown = 2f;//UŒ‚‚ÌƒN[ƒ‹ƒ_ƒEƒ“ŠÔ

    public float warningTime = 0.6f;//UŒ‚‘O‚ÌŒxŠÔ
    public float recoveryTime = 1.0f;//UŒ‚Œã‚Ì‰ñ•œŠÔ

    private float lastAttackTime;//ÅŒã‚ÉUŒ‚‚µ‚½ŠÔ
    private float stateTimer;//ó‘Ô‚Ìƒ^ƒCƒ}[

    //“G‚Ìó‘Ô‚ğŠÇ—‚·‚é—ñ‹“Œ^
    private enum  EnemyState
    {
        Move,
        Warning,
        Attack,
        Recovery
    }
    private EnemyState currentState;//“G‚ÌŒ»İ‚Ìó‘Ô
    private void Update()
    {
        
            if (player == null) return;
        //Œ»İ‚Ìó‘Ô‚É‰‚¶‚Äˆ—‚ğ•ªŠò
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
        //ƒvƒŒƒCƒ„[‚Æ“G‚Ì‹——£‚ğŒvZ
        float distanceToPlayer =
            Mathf.Abs(player.position.x - transform.position.x);

        //ƒvƒŒƒCƒ„[‚ÌˆÊ’u‚ğŒ©‚Ä“G‚ğUŒ‚Œxó‘Ô‚É‚·‚é
        if (distanceToPlayer <= attackRange)
        {
            currentState = EnemyState.Warning;
            stateTimer = warningTime;


            Debug.Log("Enemy Warning");

            return;

        }
        float direction = 
            Mathf.Sign(player.position.x-transform.position.x);

        transform.position += 
            Vector3.right *
            direction *
            MoveSpeed *
            Time.deltaTime;
    }

    private void UpdateWarning()
    {
        //ó‘Ô‚Ì•Ï‰»‚ÌŠÔ‚ğŒ¸‚ç‚·
        stateTimer -= Time.deltaTime;

        if(stateTimer <= 0)
        {
            currentState = EnemyState.Attack;//UŒ‚ó‘Ô‚É‘JˆÚ
        }
    }

    void UpdateAttack()
    {
        float distance =
            Mathf.Abs(player.position.x - transform.position.x);
        if (distance <= attackRange)
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
    void UpdateRecovery()
    {
        stateTimer -= Time.deltaTime;
        if (stateTimer <= 0f)
        {
            currentState = EnemyState.Move;
        }
    }
}