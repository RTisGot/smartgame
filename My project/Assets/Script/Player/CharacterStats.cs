using System.Xml;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [Header("Character")]
    [SerializeField]private PlayerData playerdata;

    [Header("Level")]
    [SerializeField] private int level = 1;

    [Header("Weapon")]
    [SerializeField] private WeaponData equipmentWeapon;

    [Header("Skil Tree Bonus")]
    [SerializeField] private int skillTreeHPBonus = 0;
    [SerializeField] private int skillTreePowerBonus = 0;
    [SerializeField] private int skillTreeDefenseBonus = 0;

    public string CharacterName
    {
        get
        {
            if (playerdata == null)
                return "Unknown";

            return playerdata.characterName;
        }
    }

    public int Level
    {
        get { return level; }

    }

    public int MaxHp
    {
        get { if (playerdata == null)
                return 1;

            int hp =
                    playerdata.baseHP +
                    playerdata.hpPerLevel * (level - 1);

            hp += skillTreeHPBonus;

            if (equipmentWeapon != null)
                hp += equipmentWeapon.hpBonus;
            return hp;
        }
    }

    public int power
    {
        get
        {
            if (playerdata == null)
                return 1;

            int power =
                 playerdata.baseAttack +
                 playerdata.powerPerLevel * (level - 1);

            power += skillTreePowerBonus;

            if(equipmentWeapon != null)
                power += equipmentWeapon.powerBonus;

            return power;
        }
    }

    public int Defense
    {
        get
        {
            if (playerdata == null)
                return 0;

            int defense =
                playerdata.baseDefense +
                playerdata.defensePerLevel * (level - 1);
            
            defense += skillTreeDefenseBonus;

            if(equipmentWeapon != null)
                defense += equipmentWeapon.defenseBonus;
            return defense;
        }
    }

    public string WeaponName
    {
        get
        {
            if (equipmentWeapon == null)
                return "None";

            return equipmentWeapon.WeaponName;
        }
    }
}
