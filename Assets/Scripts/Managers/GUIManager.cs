using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : BaseManager<GUIManager>
{
    public Text ScoreText;

    public Transform PopTextParent;
    public UIPop PopPrefab;

    public Transform EnemyTextParent;
    public UIEnemyText EnemyTextPrefab;

    public List<UIPop> PopList;
    public List<UIEnemyText> EnemyTextList;

    public GameObject MainMenuPanel;

    public void StartGui()
    {
        MainMenuPanel.SetActive(false);
    }

    public void StopGui()
    {
        ClearGui();
        MainMenuPanel.SetActive(true);
    }

    public void AddPop(string text)
    {
        UIPop uiPop = Utility.GetItem(ref PopList, PopPrefab, PopTextParent);
        uiPop.Execute(text);
    }

    public UIEnemyText GetEnemyText()
    {
        return Utility.GetItem(ref EnemyTextList, EnemyTextPrefab, EnemyTextParent);
    }

    public void ClearGui()
    {
        Utility.ClearList(ref EnemyTextList);
    }
}
