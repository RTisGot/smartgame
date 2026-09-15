using UnityEngine;

public class HomeUIManager : MonoBehaviour
{
    [SerializeField] private GameObject homePanel;//待機のホーム
    [SerializeField] private GameObject questPanel;//クエスト用
    [SerializeField] private GameObject characterPanel;//キャラクター用
    [SerializeField] private GameObject team;//チーム編成用
    [SerializeField] private GameObject gatchaPanel;

    [Header("Player")]
    [SerializeField] private PlayerMovement playerMovement;
    void Start()
    {
        ShowHome();
    }

    private void CloseAllPanel()
    {
        homePanel.SetActive(false);
        questPanel.SetActive(false);
        characterPanel.SetActive(false);
        team.SetActive(false);
        gatchaPanel.SetActive(false);
    }

    public void ShowHome()
    {
        CloseAllPanel();
        homePanel.SetActive(true);

        if (playerMovement != null)
        {
            playerMovement.canMove = true;
        }
    }

    public void ShowQuest()
    {
        CloseAllPanel();
        questPanel.SetActive(true);
        if (playerMovement != null)
        {
            playerMovement.canMove = false;
        }
    }

    public void ShowTeam()
    {
        CloseAllPanel();
        team.SetActive(true);

        if (playerMovement != null)
        {
            playerMovement.canMove = false;
        }
    }

    public void ShowCharacter()
    {
        CloseAllPanel();
        characterPanel.SetActive(true);

        if (playerMovement != null)
        {
            playerMovement.canMove = false;
        }
    }

    public void ShowGatcha()
    {
        CloseAllPanel();
        gatchaPanel.SetActive(true);

        if (playerMovement != null)
        {
            playerMovement.canMove = false;
        }
    }
}

