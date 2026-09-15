using UnityEngine;

[CreateAssetMenu(menuName = "Game/Player Data")]
public class PlayerData : ScriptableObject
{
    [Header("Player")]
    public string characterName;

    [Header("Base Stats")]
    public int baseHP = 100;
    public int baseAttack = 10;
    public int baseDefense = 10;

    [Header("Level Growth")]
    public int hpPerLevel = 10;
    public int powerPerLevel = 10;
    public int defensePerLevel = 10;

    [Header("Skills")]
    public SkillData skill1;
    public SkillData skill2;
    public SkillData skill3;

}
