using UnityEngine;

//どのキャラのステータスを見たいか選択するボタン用
public class CharacterSelectButton : MonoBehaviour
{
    [SerializeField] private CharacterStats characterStats;
    [SerializeField] private CharacterMenumanager menuManager;

    public void SelectCharacter()
    {
        menuManager.OpenCharacterStatus(characterStats);
    }
}
