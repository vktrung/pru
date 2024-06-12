using TMPro;
using UnityEngine;

public class PlayerUpgradeUIElement : MonoBehaviour
{
    [SerializeField] PlayerPersitentUpgrades upgrade;

    [SerializeField] TextMeshProUGUI upgradeName;
    [SerializeField] TextMeshProUGUI level;
    [SerializeField] TextMeshProUGUI price;

    [SerializeField] DataContainer dataContainer;

    private void Start()
    {
        UpdateElement();
    }

    public void Upgrade()
    {
        PlayerUpgrades playerUpgrade = dataContainer.upgrades[(int)upgrade];

        if (dataContainer.coins >= playerUpgrade.costToUpgrade)
        {
            dataContainer.coins -= playerUpgrade.costToUpgrade;
            playerUpgrade.level += 1;
            UpdateElement();
        }
    }

    void UpdateElement()
    {
        PlayerUpgrades playerUpgrade = dataContainer.upgrades[(int)upgrade];

        upgradeName.text = upgrade.ToString();
        level.text = playerUpgrade.level.ToString();
        price.text = playerUpgrade.costToUpgrade.ToString();
    }

}
