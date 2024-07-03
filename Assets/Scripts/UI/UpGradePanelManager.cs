using System.Collections.Generic;
using UnityEngine;

public class UpGradePanelManager : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] UpgradeDescriptionPanel upgradeDecripsionPanel;
    PauseManger pauseManger;

    [SerializeField] List<UpgradeButton> upgradeButtons;

    Level characterLevel;

    int selectedUpgradeID;
    List<UpGradeData> upgradesData;

    private void Awake()
    {
        pauseManger = GetComponent<PauseManger>();
        characterLevel = GameManager.instance.playerTransform.GetComponent<Level>();
    }

    private void Start()
    {
        HideButton();
        selectedUpgradeID = -1;
    }

    public void OpenPanel(List<UpGradeData> upGradeDatas)
    {
        Clean();
        pauseManger.PauseGame();
        panel.SetActive(true);

        this.upgradesData = upGradeDatas;

        for (int i = 0; i < upGradeDatas.Count; i++)
        {
            upgradeButtons[i].gameObject.SetActive(true);
            upgradeButtons[i].Set(upGradeDatas[i]);
        }
    }

    public void Clean()
    {
        for (int i = 0; i < upgradeButtons.Count; i++)
        {
            upgradeButtons[i].Clean();
        }
    }

    public void Upgared(int pressedButtonID)
    {
        if (selectedUpgradeID != pressedButtonID)
        {
            selectedUpgradeID = pressedButtonID;
            ShowDescription();
        }
        else
        {
            characterLevel.Upgrade(pressedButtonID);
            ClosePanel();
            HideDescription();
        }
    }

    private void HideDescription()
    {
        upgradeDecripsionPanel.gameObject.SetActive(false);
    }

    private void ShowDescription()
    {
        upgradeDecripsionPanel.gameObject.SetActive(true);
        upgradeDecripsionPanel.Set(upgradesData[selectedUpgradeID]);
    }

    public void ClosePanel()
    {
        selectedUpgradeID = -1;

        HideButton();

        pauseManger.UnPauseGame();
        panel.SetActive(false);
    }

    private void HideButton()
    {
        for (int i = 0; i < upgradeButtons.Count; i++)
        {
            upgradeButtons[i].gameObject.SetActive(false);
        }
    }
}
