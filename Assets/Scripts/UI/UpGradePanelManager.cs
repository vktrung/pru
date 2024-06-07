using System.Collections.Generic;
using UnityEngine;

public class UpGradePanelManager : MonoBehaviour
{
    [SerializeField] GameObject panel;
    PauseManger pauseManger;

    [SerializeField] List<UpgradeButton> upgradeButtons;

    private void Awake()
    {
        pauseManger = GetComponent<PauseManger>();
    }

    private void Start()
    {
        HideButton();
    }

    public void OpenPanel(List<UpGradeData> upGradeDatas)
    {
        Clean();
        pauseManger.PauseGame();
        panel.SetActive(true);


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
        GameManager.instance.playerTransform.GetComponent<Level>().Upgrade(pressedButtonID);
        ClosePanel();
    }

    public void ClosePanel()
    {
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
