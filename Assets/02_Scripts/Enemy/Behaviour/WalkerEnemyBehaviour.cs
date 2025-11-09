using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class WalkerEnemyBehaviour : EnemyBehaviour
{
    [SerializeField] private float node_Completion_Radius = 0.5f;
    private bool canJump;
    List<Node> currentPath;

    public override void Move(BaseEnemy enemy)
    {
        enemy.StartCoroutine(Start(enemy));
    }
    private bool DeterminIfCanJump()
    {
        return false;
    }

    IEnumerator Start(BaseEnemy enemy)
    {
        NavMeshAgent agent = enemy.agent;
        agent.autoTraverseOffMeshLink = false;
        while (true)
        {
            if (!agent.isActiveAndEnabled) 
            {
                break;
            }
            agent.speed = enemy.speed;
            if (agent.isOnNavMesh) 
            {
                agent.SetDestination(enemy.target.position);
            
            }
            if (agent.isOnOffMeshLink)
            {
                yield return enemy.StartCoroutine(Parabola(agent, 2.0f, 0.5f));
                agent.CompleteOffMeshLink();
            }

            yield return null;
        }
    }

    IEnumerator Parabola(NavMeshAgent agent, float height, float duration)
    {
        OffMeshLinkData data = agent.currentOffMeshLinkData;
        Vector3 startPos = agent.transform.position;
        Vector3 endPos = data.endPos + Vector3.up * agent.baseOffset;
        float normalizedTime = 0.0f;
        while (normalizedTime < 1.0f)
        {
            float yOffset = height * 4.0f * (normalizedTime - normalizedTime * normalizedTime);
            agent.transform.position = Vector3.Lerp(startPos, endPos, normalizedTime) + yOffset * Vector3.up;
            normalizedTime += Time.deltaTime / duration;
            yield return null;
        }
    }

}
