using UnityEngine;

namespace Services
{
    [CreateAssetMenu]
    public class PlayerData : ScriptableObject
    {
        public GameObject playerPrefab;
        public float playerSpeed;
    }
}