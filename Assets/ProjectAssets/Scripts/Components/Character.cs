using UnityEngine;

namespace ProjectAssets.Scripts.Components
{
    public struct Character
    {
        public Rigidbody2D rigidbody2D;
        public CircleCollider2D collider2D;
        public float speed;
        public GameObject gameObject;
    }
}