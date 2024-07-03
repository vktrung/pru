using TMPro;
using UnityEngine;

public class UpgradeDescriptionPanel : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI upgradeNameText;
    [SerializeField] TextMeshProUGUI upgradeDescription;

    public void Set(UpGradeData upgradeData)
    {
        upgradeNameText.text = upgradeData.Name;
        upgradeDescription.text = upgradeData.Description;
    }
}
