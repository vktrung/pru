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
    PassiveItem passiveItem;

    [SerializeField] List<UpGradeData> upgradesAvailableOnStart;

    private void Awake()
    {
        weaponManager = GetComponent<WeaponManager>();
        passiveItem = GetComponent<PassiveItem>();
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
        AddUpgradesIntoTheListOfAvailableUpgrades(upgradesAvailableOnStart);
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

    public void ShuffleUpgrades()
    {
        for (int i = upgrades.Count - 1; i > 0; i--)
        {
            int x = Random.Range(0, i + 1);
            UpGradeData suffleElement = upgrades[i];
            upgrades[i] = upgrades[x];
            upgrades[x] = suffleElement;
        }
    }

    public List<UpGradeData> GetUpgrade(int count)
    {
        ShuffleUpgrades();
        List<UpGradeData> upgradeList = new List<UpGradeData>();

        if (count > upgrades.Count)
        {
            count = upgrades.Count;
        }

        for (int i = 0; i < count; i++)
        {
            upgradeList.Add(upgrades[i]);
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
                weaponManager.UpgradeWeapon(upgradeData);
                break;
            case UpgradeType.ItemUpgrade:
                passiveItem.UpgradeItem(upgradeData);
                break;
            case UpgradeType.WeaponUnlock:
                weaponManager.AddWeapon(upgradeData.weaponData);
                break;
            case UpgradeType.ItemUnlock:
                passiveItem.Equip(upgradeData.item);
                AddUpgradesIntoTheListOfAvailableUpgrades(upgradeData.item.upgrades);
                break;
        }

        acquiredUpgrade.Add(upgradeData);
        upgrades.Remove(upgradeData);
    }

    internal void AddUpgradesIntoTheListOfAvailableUpgrades(List<UpGradeData> upgradesToAdd)
    {
        if (upgradesToAdd == null) { return; }
        this.upgrades.AddRange(upgradesToAdd);
    }
}
