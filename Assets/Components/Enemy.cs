using UnityEngine;

namespace Components
{
    public struct Enemy
    {
        public Rigidbody2D enemyRigidbody2D;
        public CircleCollider2D enemyCollider2D;
        public float enemySpeed;
        public GameObject enemyGameObject;
    }
}