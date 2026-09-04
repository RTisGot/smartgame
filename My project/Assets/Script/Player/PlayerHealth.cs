using JetBrains.Annotations;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;//最大体力
    private int currentHP;//現在の体力

    private void Start()
    {
        currentHP = maxHealth;//現在の体力を最大体力に設定
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;//ダメージを受けた分だけ体力を減らす
        if (currentHP <= 0)
        {
            currentHP = 0;//HPを0にする
        }

        Debug.Log("Player HP :" + currentHP);//現在の体力を表示

        if(currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player defeated!");
    }
}
