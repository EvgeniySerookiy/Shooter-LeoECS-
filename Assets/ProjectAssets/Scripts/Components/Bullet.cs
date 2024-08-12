using UnityEngine;

namespace ProjectAssets.Scripts.Components
{
    public struct Bullet
    {
        public Rigidbody2D bulletRigidbody2D;
        public CircleCollider2D bulletCollider2D;
        public float bulletSpeed;
        public float bulletLifeTime;
        public GameObject bulletGameObject;
    }
}