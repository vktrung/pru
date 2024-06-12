using System;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerPersitentUpgrades
{
    HP,
    Damage
}

[Serializable]
public class PlayerUpgrades
{
    public PlayerPersitentUpgrades persitentUpgrades;
    public int level = 0;
    public int costToUpgrade = 100;
}

[CreateAssetMenu]
public class DataContainer : ScriptableObject
{
    public int coins;

    public List<bool> stageCompletion;

    public List<PlayerUpgrades> upgrades;

    public void StageComplete(int i)
    {
        stageCompletion[i] = true;
    }
}
