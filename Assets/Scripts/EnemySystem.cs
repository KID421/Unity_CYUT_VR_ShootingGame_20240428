using UnityEngine;
using UnityEngine.AI;
using System.Collections;       // 協同程序 Coroutine 需要的命名空間

public class EnemySystem : MonoBehaviour
{
    [SerializeField, Header("導覽代理器")]
    private NavMeshAgent agent;
    [SerializeField, Header("動畫控制器")]
    private Animator ani;
    [SerializeField, Header("敵人攻擊區域")]
    private GameObject attackArea;

    private Transform playerPoint;
    private string parMove = "移動數值";
    private string parAttack = "觸發攻擊";
    private bool isAttacking;

    private void Awake()
    {
        playerPoint = GameObject.Find("玩家").transform;

        Move();
    }

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
            StartCoroutine(StartAttack());
        }
    }

    private IEnumerator StartAttack()
    {
        yield return new WaitForSeconds(0.5f);
        // 顯示 敵人攻擊區域
        attackArea.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        attackArea.SetActive(false);
        isAttacking = false;
    }
}
