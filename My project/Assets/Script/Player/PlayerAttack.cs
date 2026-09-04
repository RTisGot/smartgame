using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint; // 攻撃の中心点
    public float attackRange = 1.2f; // 攻撃範囲
    public int attackDamage = 10; // 攻撃力

    public LayerMask enemyLayer;// 敵のレイヤーを指定するための変数
    public float attackPointDistance = 1.0f;// 攻撃ポイントまでの距離

    public PlayerMovement movement; // PlayerMovementスクリプトへの参照

    void Start()
    {
        movement = GetComponent<PlayerMovement>();// PlayerMovementスクリプトを取得
    }
    void Update()
    {
        UpdateAttackPoint();
        if (Input.GetKeyDown(KeyCode.J))
        {
            Attack();
        }
    }

    void UpdateAttackPoint()
    {
        // 動いていない,攻撃ポイントがない場合は処理を中断
        if (movement == null || attackPoint == null) return;

        Vector3 localPosition = attackPoint.localPosition;//親の位置から見てキャラの向きに応じて攻撃ポイントの位置を更新 

        localPosition.x =
            attackPointDistance * movement.facingDirection;

        attackPoint.localPosition = localPosition;
    }

    private void Attack()
    {
        Collider[] enemies = Physics.OverlapSphere(
            attackPoint.position,
            attackRange,
            enemyLayer
            );

        // 敵にダメージを与える
        foreach (Collider enemy in enemies)
        {
            EnemyHealth health = enemy.GetComponent<EnemyHealth>();// EnemyHealthスクリプトを取得

            if (health != null)
            {
                health.TakeDamage(attackDamage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(
            attackPoint.position,
            attackRange
            );
    }
}
