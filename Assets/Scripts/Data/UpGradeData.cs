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
    public string Description;
    public Sprite icon;

    public WeaponData weaponData;
    public WeaponStats weaponUpgradeStats;

    public Item item;
    public ItemStats itemStats;
}
