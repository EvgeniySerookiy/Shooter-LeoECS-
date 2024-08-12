using UnityEngine;

namespace ProjectAssets.Scripts.Services
{
    [CreateAssetMenu]
    public class EnemyData : ScriptableObject
    {
        public GameObject enemyPrefab;
        public float enemySpeed;
        public float spawnInterval;
        public float spawnDistance;
    }
}