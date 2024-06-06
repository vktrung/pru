using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] Transform weaponObjectsContainer;
    [SerializeField] WeaponData startingWeapon;

    private void Start()
    {
        AddWeapon(startingWeapon);
    }

    public void AddWeapon(WeaponData weaponData)
    {
        GameObject weaponGameObject = Instantiate(weaponData.weaponBasePrefabs, weaponObjectsContainer);

        weaponGameObject.GetComponent<WeaponBase>().SetData(weaponData);

    }
}
