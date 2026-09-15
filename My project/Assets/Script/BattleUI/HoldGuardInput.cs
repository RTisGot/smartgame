using NUnit.Framework.Interfaces;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoldGuardInput : MonoBehaviour,
    IPointerDownHandler,
    IPointerUpHandler
{
    [Header("Guard")]
    [SerializeField] private PlayerParry playerParry;

    [Header("Hold Settings")]
    [SerializeField] private float holdTime = 0.25f;

    private bool isPressing;
    private bool guardStarted;
    private float pressTimer;

    private void Update()
    {
        if (isPressing || guardStarted) return;

        pressTimer += Time.deltaTime;

        //ˆê’èŠÔ‰Ÿ‚µ‘±‚¯‚½
        if ((pressTimer >= holdTime))
        {
            StartGuard();
        }
    }

    //’·‰Ÿ‚µ‚³‚ê‚½‚Æ‚«
    public void OnPointerDown(PointerEventData eventData)
    {
        isPressing = true;
        guardStarted = false;
        pressTimer = 0f;
    }

    //’·‰Ÿ‚µ‚ğ—£‚µ‚½‚Æ‚«‚Ìˆ—
    public void OnPointerUp(PointerEventData eventData)
    {
        isPressing = false;
        pressTimer = 0f;

        if (guardStarted)
        {
            playerParry.EndGuard();
            guardStarted = false;
        }
    }

    private void StartGuard()
    {
        if (playerParry == null) return;

        guardStarted = true;

        playerParry.StartGuard();

    }
}
