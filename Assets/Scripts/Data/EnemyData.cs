using UnityEngine;

[CreateAssetMenu]
public class EnemyData : ScriptableObject
{
    public string Name;
    public PoolObjectData poolObjectData;
    public EnemyStats stats;
}
