using System.Collections;
using UnityEngine;

public class PlayerParry : MonoBehaviour
{
    [Header("parry")]
    [SerializeField] private float parryWindow = 0.2f;

    private bool isParrying;
    private bool isGuarding;

    public bool IsParrying => isParrying;
    public bool IsGuarding => isGuarding;

    //ガードボタンを押した瞬間
    public void StartGuard()
    {
        if (isGuarding) return;
        isGuarding = true;
        StartCoroutine(ParryWindow());
    }

    public void EndGuard()
    {
        isGuarding = false;
        isParrying = false;
    }

    private IEnumerator ParryWindow()
    {
        isParrying = true;

        yield return new WaitForSeconds(parryWindow);//できる時間を設定

        isParrying = false;
    }

    public void ParrySuccess()
    {
        isParrying = false;
    }
}
