using UnityEngine;

namespace Services
{
    [CreateAssetMenu]
    public class BulletData : ScriptableObject
    {
        public GameObject bulletPrefab;
        public float bulletSpeed;
        public float bulletLifeTime;
    }
}