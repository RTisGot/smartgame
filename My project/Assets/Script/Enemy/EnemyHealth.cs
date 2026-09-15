using UnityEngine;
using UnityEngine.UI;
using TMPro;
// 敵の体力を管理するクラス
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private GameObject damageTextPrefab;
    [SerializeField] private Transform damageTextPoint;
    [Header("HP")]
    public int maxHP = 100; // 最大体力
    private int currentHP; // 現在の体力

    [Header("HP UI")]
    [SerializeField] private Slider hpSlider;
    [SerializeField] private TMP_Text hpText;

    private void Start()
    {
        currentHP = maxHP;
        UpdateHPUI();
    }

    //
    public void TakeDamage(int damage)
    {
        currentHP = Mathf.Max(currentHP - damage, 0); // 体力を減らすが、0未満にはならないようにする

        ShowDamageText(damage);
        Debug.Log("Enemy HP :" + currentHP);
        UpdateHPUI();
        if(currentHP <= 0)
        {
            Die();
        }
    }

    //ダメージテキスト表示用関数
    private void ShowDamageText(int damage)
    {
        if (damageTextPrefab == null) return;

        //表示場所
        Vector3 spawnPosition =
            damageTextPoint != null
            ? damageTextPoint.position
            : transform.position + Vector3.up * 3f;

        GameObject obj = Instantiate(
            damageTextPrefab,
            spawnPosition,
            Quaternion.identity
            );

        DamageText text =
            obj.GetComponent<DamageText>();

        if(text != null)
            {
            text.Setup(damage);
        }
    }


    private void UpdateHPUI()
    {
        if(hpSlider != null)
        {
            hpSlider.maxValue = maxHP;
            hpSlider.value = currentHP;
        }
    }
    public void Die()
    {
        Debug.Log("Enemy defeated!");

        Destroy(gameObject);
    }
}
