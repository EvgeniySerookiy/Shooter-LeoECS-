using UnityEngine;

namespace ProjectAssets.Scripts.Services
{
    [CreateAssetMenu]
    public class BulletData : ScriptableObject
    {
        public GameObject bulletPrefab;
        public float bulletSpeed;
        public float bulletLifeTime;
    }
}