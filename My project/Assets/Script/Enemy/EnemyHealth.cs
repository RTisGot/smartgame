using UnityEngine;
// “G‚Ì‘Ì—Í‚ğŠÇ—‚·‚éƒNƒ‰ƒX
public class EnemyHealth : MonoBehaviour
{
    public int maxHP = 100; // Å‘å‘Ì—Í

    private int currentHP; // Œ»İ‚Ì‘Ì—Í

    private void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        currentHP = Mathf.Max(currentHP - damage, 0); // ‘Ì—Í‚ğŒ¸‚ç‚·‚ªA0–¢–‚É‚Í‚È‚ç‚È‚¢‚æ‚¤‚É‚·‚é

        Debug.Log("Enemy HP :" + currentHP);

        if(currentHP <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        Debug.Log("Enemy defeated!");

        Destroy(gameObject);
    }
}
