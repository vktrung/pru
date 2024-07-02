using UnityEngine;

[CreateAssetMenu]
public class CharacterData : ScriptableObject
{
    public string Name;
    public GameObject spritePrefab;
    public WeaponData startingWeapon;
}
