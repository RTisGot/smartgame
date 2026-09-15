using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI damageText;
    [SerializeField] private float moveSpeed = 1.5f;
    [SerializeField] private float lifeTime = 0.8f;

    private void Awake()
    {
        damageText = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void Update()
    {
        transform.position +=
            Vector3.up * moveSpeed * Time.deltaTime;

        lifeTime -= Time.deltaTime;

        if(lifeTime <=  0f)
        {
            Destroy(gameObject);
        }
    }

    public void Setup(int damage)
    {
        damageText.text = damage.ToString();
    }

    public void LateUpdate()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;

        if(Camera.main != null)
        {
            transform.rotation = Camera.main.transform.rotation;
        }
        lifeTime -= Time.deltaTime;

        if(lifeTime <= 0f)
        {
            Destroy(gameObject);
        }

    }
}
