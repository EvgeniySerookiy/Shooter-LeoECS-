using UnityEngine;

namespace Components
{
    public struct Player
    {
        public Rigidbody2D playerRigidbody2D;
        public CircleCollider2D playerCollider2D;
        public float playerSpeed;
        public GameObject playerGameObject;
    }
}