using System.IO.Enumeration;
using UnityEngine;

//ステージのデータ

[CreateAssetMenu(
    fileName =  "NewStage",
    menuName = "Game/Stage Data"
    )]
public class StageData : ScriptableObject
{
    [Header("Stage")]
    public int stageID;
    public string stageName;

    [TextArea]
    public string description;

    [Header("Difficulty")]
    public int recommendedLevel = 1;//推奨レベル

    [Header("Reward")]
    public int goldReward = 100;

    [Header("Scene")]
    public string sceneName;
   
}
