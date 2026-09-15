using UnityEngine;
using UnityEngine.TextCore.Text;

[CreateAssetMenu(fileName = "NewSkillData",
    menuName = "Game/Skill Data")]
public class SkillData : ScriptableObject
{
    [Header("Basic")]
    public string skillName;
    public Sprite icon;

    [Header("SP")]
    public int spCost = 20;

    [Header("Damage")]
    public int baseDamage = 50;
    public float powerMultiplier = 1.5f;

    [Header("Range")]
    public float attackRange = 2f;

    [Header("Other")]
    public float cooldown = 3f;

}
