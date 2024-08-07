using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] Transform weaponObjectsContainer;
    [SerializeField] PoolManager poolManager;

    List<WeaponBase> weapons;

    Character character;

    private void Awake()
    {
        weapons = new List<WeaponBase>();
        character = GetComponent<Character>();
    }


    public void AddWeapon(WeaponData weaponData)
    {
        GameObject weaponGameObject = Instantiate(weaponData.weaponBasePrefabs, weaponObjectsContainer);

        WeaponBase weaponBase = weaponGameObject.GetComponent<WeaponBase>();

        weaponBase.SetData(weaponData);
        weaponBase.SetPoolManager(poolManager);

        weapons.Add(weaponBase);
        weaponBase.AddOwnerCharacter(character);

        Level level = GetComponent<Level>();
        if (level != null)
        {
            level.AddUpgradesIntoTheListOfAvailableUpgrades(weaponData.upgrades);
        }
    }

    internal void UpgradeWeapon(UpGradeData upgradeData)
    {
        WeaponBase weaponToUpgrade = weapons.Find(wd => wd.weaponData == upgradeData.weaponData);
        weaponToUpgrade.Upgrade(upgradeData);
    }
}
