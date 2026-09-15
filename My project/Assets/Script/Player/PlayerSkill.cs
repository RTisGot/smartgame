using System.Xml.Serialization;
using UnityEditor.UIElements;
using UnityEngine;

/**プレイヤーのスキル**/
public class PlayerSkill : MonoBehaviour
{
    [Header("Skills")]
    [SerializeField] private SkillData skill1;
    [SerializeField] private SkillData skill2;
    [SerializeField] private SkillData skill3;

    [Header("SP")]
    [SerializeField] private int maxSP = 100;
    [SerializeField] private int currentSP = 100;

    [Header("Attack")]
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask enemyLayer;

    private CharacterStats stats;

    public int CurrentSP => currentSP;
    public int MaxSP => maxSP;

    private void Awake()
    {
        stats = GetComponent<CharacterStats>();

        currentSP = maxSP;

        if(stats == null)
        {
            Debug.LogWarning("PlayerSkill: CharacterStatsが見つかりません");
        }
    }

    //skill1

    public void UseSkill1()
    {
        if(skill1 == null)
        {
            Debug.LogError("SkillのSkilDataが見つかりません");
            return;
        }

        TryUseSkill(skill1);
    }

    public void UseSkill2()
    {
        if (skill2 == null)
        {
            Debug.LogError("Skill2のSkillDataが見つかりません");
            return;
        }
        TryUseSkill(skill2);
    }

    private void UseSkill3()
    {
        if(skill3 == null)
        {
            Debug.LogError("Skill3のSkillDataが見つかりません");
            return;
        }

        TryUseSkill(skill3);
    }

    private void TryUseSkill(SkillData skill)
    {
        if (skill == null) return;

        //SP不足
        if (currentSP < skill.spCost) return;

        currentSP -= skill.spCost;

        currentSP = Mathf.Clamp(
            currentSP,
            0,
            maxSP
            );

        DealSkillDamage(skill);
    }


    //skillダメージ
    private void DealSkillDamage(SkillData skill)
    {
        if (attackPoint == null) return;

        Collider[] enemies =
            Physics.OverlapSphere(
                attackPoint.position,
                skill.attackRange,
                enemyLayer
                );

        foreach(Collider enemy in enemies)
        {
            EnemyHealth enemyHealth = enemy.GetComponentInParent<EnemyHealth>();

            if (enemyHealth == null) continue;

            int damage = skill.baseDamage;

            if (stats != null)
            {
                damage += Mathf.RoundToInt(
                    stats.power *
                    skill.powerMultiplier);
            }

            enemyHealth.TakeDamage(damage);
        }
    }

    public void AddSP(int amount)
    {
        currentSP += amount;//amountを加算

        currentSP += Mathf.Clamp(
            currentSP,
            0,
            maxSP
                );

        Debug.Log(
            "SP +" +
            amount +
            "現在SP:" +
            currentSP
            );
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint) return;

        if(skill1 != null)
        {
            Gizmos.DrawWireSphere(
                attackPoint.position,
                skill1.attackRange);
        }
    }

}
