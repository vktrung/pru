using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] Image icon;

    public void Set(UpGradeData upgradeData)
    {
        icon.sprite = upgradeData.icon;
    }

    internal void Clean()
    {
        icon.sprite = null;
    }
}
