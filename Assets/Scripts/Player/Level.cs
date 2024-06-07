using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    int level = 1;
    int exp = 0;
    [SerializeField] ExperienceBar experienceBar;
    [SerializeField] UpGradePanelManager upgradePanel;


    [SerializeField] List<UpGradeData> upgrades;
    List<UpGradeData> selectedUpgrades;
    [SerializeField] List<UpGradeData> acquiredUpgrade;

    WeaponManager weaponManager;

    private void Awake()
    {
        weaponManager = GetComponent<WeaponManager>();
    }


    int TO_LEVEL_UP
    {
        get
        {
            return level * 1000;
        }
    }

    private void Start()
    {
        experienceBar.UpdateExpSlider(exp, TO_LEVEL_UP);
        experienceBar.SetLevelText(level);
    }

    public void AddExperience(int amount)
    {
        exp += amount;
        CheckLevelUp();
        experienceBar.UpdateExpSlider(exp, TO_LEVEL_UP);
    }

    public void CheckLevelUp()
    {
        if (exp >= TO_LEVEL_UP)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        if (selectedUpgrades == null) { selectedUpgrades = new List<UpGradeData>(); }
        selectedUpgrades.Clear();
        selectedUpgrades.AddRange(GetUpgrade(4));

        upgradePanel.OpenPanel(selectedUpgrades);
        exp -= TO_LEVEL_UP;
        level += 1;
        experienceBar.SetLevelText(level);
    }

    public List<UpGradeData> GetUpgrade(int count)
    {
        List<UpGradeData> upgradeList = new List<UpGradeData>();

        if (count > upgrades.Count)
        {
            count = upgrades.Count;
        }

        for (int i = 0; i < count; i++)
        {
            upgradeList.Add(upgrades[Random.Range(0, upgrades.Count)]);
        }


        return upgradeList;
    }

    internal void Upgrade(int selectedUpgradeId)
    {
        UpGradeData upgradeData = selectedUpgrades[selectedUpgradeId];

        if (acquiredUpgrade == null) { acquiredUpgrade = new List<UpGradeData> { upgradeData }; }

        switch (upgradeData.type)
        {
            case UpgradeType.WeaponUpgrade:
                break;
            case UpgradeType.ItemUpgrade:
                break;
            case UpgradeType.WeaponUnlock:
                weaponManager.AddWeapon(upgradeData.weaponData);
                break;
            case UpgradeType.ItemUnlock:
                break;
        }

        acquiredUpgrade.Add(upgradeData);
        upgrades.Remove(upgradeData);
    }

    internal void AddUpgradesIntoTheListOfAvailableUpgrades(List<UpGradeData> upgradesToAdd)
    {
        this.upgrades.AddRange(upgradesToAdd);
    }
}
