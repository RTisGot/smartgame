using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

//QuestÇÃíÜêgÇä«óùÇ∑ÇÈscript
public class QuestmenuManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject questCategoryPanel;
    [SerializeField] private GameObject stageMapPanel;
    [SerializeField] private GameObject stageDetailPanel;
    [SerializeField] private GameObject partyPanel;
    [Header("Detail")]
    [SerializeField] private TMP_Text stageNameText;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private TMP_Text rewardText;
    private StageData selectedStage;

    public void OpenQuestMenu()
    {
        questCategoryPanel.SetActive(true);

        stageMapPanel.SetActive(false);
        stageDetailPanel.SetActive(false);
        partyPanel.SetActive(false);
    }

    public void OpenMainQuest()
    {
        questCategoryPanel.SetActive(false);

        stageMapPanel.SetActive(true);
        stageDetailPanel.SetActive(true);
        partyPanel.SetActive(false);
    }
    public void OpenStageMap()
    {
        questCategoryPanel.SetActive(false);
        stageMapPanel.SetActive(true);
        stageDetailPanel.SetActive(false);
    }
    public void SelectStage(StageData stage)
    {
        selectedStage = stage;

        questCategoryPanel.SetActive(false);
        stageMapPanel.SetActive(true);
        stageDetailPanel.SetActive(true);
        partyPanel.SetActive(false);
        stageNameText.text = stage.stageName;
        levelText.text =
            "êÑèß Lv." + stage.recommendedLevel;
        rewardText.text =
            stage.goldReward + " Gold";

        SceneManager.LoadScene(selectedStage.sceneName);
    }

    public void OpenPartyPanel()
    {
        if (partyPanel == null) return;

        stageMapPanel.SetActive(false);
        stageDetailPanel.SetActive(false);
        partyPanel.SetActive(true);
    }
    public void CloseStageDetail()
    {
        stageDetailPanel.SetActive(false);
    }
}