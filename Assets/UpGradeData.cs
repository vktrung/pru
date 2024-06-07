using UnityEngine;

public enum UpgradeType
{
    WeaponUpgrade,
    ItemUpgrade,
    WeaponUnlock,
    ItemUnlock
}


[CreateAssetMenu]
public class UpGradeData : ScriptableObject
{
    public UpgradeType type;
    public string Name;
    public Sprite icon;
}
