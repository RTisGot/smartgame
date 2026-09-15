using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class QuestmenuManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject stageListPanel;
    [SerializeField] private GameObject partyPanel;

    [Header("Party UI")]
    [SerializeField]private TMP_Text stageNameText;
    private string selectedStageName;

    private void Start()
    {
        ShowStageList();
    }

    public void SelectStage(string stageName)
    {
        selectedStageName = stageName;

        stageListPanel.SetActive(false);
        partyPanel.SetActive(true);

        if (stageNameText != null)
            stageNameText.text = stageName;
    }

    public void BackToStageList()
    {
        partyPanel.SetActive(false);
        stageListPanel.SetActive(true);
    }

    public void StartBattle()
    {
        SceneManager.LoadScene("MainBattle");
    }

    private void ShowStageList()
    {
        stageListPanel.SetActive(true);
        partyPanel.SetActive(false);
    }
}
