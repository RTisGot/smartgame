using UnityEngine;

//ステージボタンを押せるようにするためのscript
public class StageButton : MonoBehaviour
{
    [SerializeField] private StageData stageData;
    [SerializeField] private QuestmenuManager questMenuManager;

    public void SelectStage()
    {
        if (stageData == null) return;

        if (questMenuManager == null) return;

        questMenuManager.SelectStage(stageData);
    }
}
