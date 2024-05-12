using UnityEngine;
using UnityEngine.AI;

public class EnemySystem : MonoBehaviour
{
    [SerializeField, Header("玩家")]
    private Transform playerPoint;
    [SerializeField, Header("導覽代理器")]
    private NavMeshAgent agent;
    [SerializeField, Header("動畫控制器")]
    private Animator ani;

    private string parMove = "移動數值";
    private string parAttack = "觸發攻擊";
    private bool isAttacking;

    private void Update()
    {
        Move();
        Attack();
    }

    private void Move()
    {
        // 代理器 的 設定目的地 (玩家的座標)
        agent.SetDestination(playerPoint.position);

        // 動畫控制器 設定浮點數(參數名稱，浮點數)
        ani.SetFloat(parMove, agent.velocity.magnitude / agent.speed);
    }

    private void Attack()
    {
        // 如果 正在攻擊中 就跳出
        if (isAttacking) return;

        // print($"<color=#6f9>距離：{agent.remainingDistance}</color>");

        // 如果 剩餘距離 <= 停止距離 就攻擊
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            ani.SetTrigger(parAttack);
            isAttacking = true;
        }
    }
}
