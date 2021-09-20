using UnityEngine;

namespace Assets.Client.Scripts
{
    [CreateAssetMenu]
    public class GameSettings : ScriptableObject
    {
        public int ColCount;
        public int RowCount;

        public float speed;
    }
}