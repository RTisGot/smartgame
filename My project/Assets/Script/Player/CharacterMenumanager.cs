using TMPro;
using UnityEngine;

/**キャラクターステータス表示用**/
public class CharacterMenumanager : MonoBehaviour
{
    [Header("Panel")]
    [SerializeField] private GameObject characterListPanel;
    [SerializeField] private GameObject characterStatusPanel;

    [Header("Status UI")]
    [SerializeField] private TMP_Text name_Text;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private TMP_Text hpText;
    [SerializeField] private TMP_Text powerText;
    [SerializeField] private TMP_Text defenseText;
    [SerializeField] private TMP_Text weaponText;

    public void OpenCharacterStatus(CharacterStats character)
    {
        characterListPanel.SetActive(true);
        characterStatusPanel.SetActive(true);

        name_Text.text = character.name;
        levelText.text = "Lv." + character.Level;
        hpText.text = "HP :" + character.MaxHp;
        powerText.text = "Defense : " + character.power;
        defenseText.text = "Defense :" + character.Defense;
        weaponText.text = "Weapon :" + character.WeaponName;
    }
}
