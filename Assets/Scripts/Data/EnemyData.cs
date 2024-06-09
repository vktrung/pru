using UnityEngine;

[CreateAssetMenu]
public class EnemyData : ScriptableObject
{
    public string Name;
    public GameObject animatedPrefab;
    public EnemyStats stats;
}
