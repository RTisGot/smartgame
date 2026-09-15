using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    private bool isStarting = false;

    private void Update()
    {
        if (isStarting) return;

        //PC用
        if(Input.GetMouseButtonDown(0))
        {
            StartGame();
        }

        //スマホ用
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            StartGame();
        }
    }

    void StartGame()
    {
        isStarting = true;

        SceneManager.LoadScene("Waitingroom");
    }


}
