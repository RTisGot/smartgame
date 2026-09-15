using UnityEngine;
using TMPro;

public class TitleBlink : MonoBehaviour
{
    [SerializeField]
    private TMP_Text titleText;

    [SerializeField]
    float speed = 2f; // “_–Å‚Ì‘¬“x

    private void Update()
    {
        if (titleText == null) return;

        Color color = titleText.color;

        color.a =
            Mathf.Lerp(
                0.3f,
                1f,
                (Mathf.Floor(Mathf.Sin(Time.time * speed) + 1f) * 0.5f));
        titleText.color = color;
    }
}
