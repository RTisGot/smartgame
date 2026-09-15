using UnityEngine;

[CreateAssetMenu(menuName ="Game/Weapom Data")]
public class WeaponData : MonoBehaviour
{
    [Header("weapon")]
    public string WeaponName;

    [Header("Stat Bonus")]
    public int hpBonus = 0;
    public int powerBonus = 0;
    public int defenseBonus = 0;

}
