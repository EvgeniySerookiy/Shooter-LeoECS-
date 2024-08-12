using UnityEngine;

namespace ProjectAssets.Scripts.Services
{
    [CreateAssetMenu]
    public class PlayerData : ScriptableObject
    {
        public GameObject playerPrefab;
        public float playerSpeed;
    }
}