using UnityEngine;

namespace KID
{
    /// <summary>
    /// 生成敵人系統
    /// </summary>
    public class SpawnEnemySystem : MonoBehaviour
    {
        [SerializeField, Header("敵人預製物")]
        private GameObject prefabEnemy;
        [SerializeField, Header("生成點")]
        private Transform[] spawnPoints;
        [SerializeField, Header("生成間隔範圍")]
        private Vector2 spawnIntervalRange = new Vector2(1, 3);

        /// <summary>
        /// 隨機間隔：獲得生成間隔範圍內的隨機時間，1 ~ 3 秒內隨機
        /// </summary>
        private float randomInterval => Random.Range(spawnIntervalRange.x, spawnIntervalRange.y);

        private void Awake()
        {
            // 延遲隨機間隔時間生成下一隻敵人
            Invoke("SpawnEnemy", randomInterval);
        }

        private void SpawnEnemy()
        {
            // 隨機獲得一個生成點
            int random = Random.Range(0, spawnPoints.Length);
            // 生成敵人在隨機生成點上
            Instantiate(prefabEnemy, spawnPoints[random].position, spawnPoints[random].rotation);
            // 延遲隨機間隔時間生成下一隻敵人
            Invoke("SpawnEnemy", randomInterval);
        }
    }
}
