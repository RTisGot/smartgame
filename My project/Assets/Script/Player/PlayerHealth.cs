using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private CharacterStats stats;
    private int currentHP;//現在の体力
    [Header("UI")]
    public Slider hpSlider; // HPバーのSliderコンポーネントへの参照
    public TMP_Text hpText;// HPバーのテキスト表示用のTextMeshProUGUIコンポーネントへの参照
    [SerializeField] public TMP_Text dieText;

    private void Start()
    {
        currentHP = stats.MaxHp;//現在の体力を最大体力に設定

        UpdateHPUI();
       
    }

    public void TakeDamage(int damage)
    {
        PlayerParry parry = GetComponent<PlayerParry>();

        if (parry != null && parry.IsParrying)
        {
            parry.ParrySuccess();
            return;
        }

        if(parry != null && parry.IsGuarding)
        {
            damage = Mathf.RoundToInt(damage * 0.5f);

        }
        int finalDamage =
             Mathf.Max(1, damage - stats.Defense);

        currentHP -= finalDamage;

        currentHP =
            Mathf.Clamp(currentHP, 0, stats.MaxHp);

        UpdateHPUI();

        if(currentHP <= 0)
        {
            Die();
        }
    }

    void UpdateHPUI()
    {
        if (hpSlider != null)
        {
            hpSlider.maxValue = stats.MaxHp;
            hpSlider.value = currentHP;
        }

        if ((hpText != null))
        {
            hpText.text = currentHP + "/" + stats.MaxHp;
        }
    }


    void Die()
    {
        Debug.Log("Player defeated!");
    }
}
