using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent meshAgent;
    public Transform trans;

    // Start is called before the first frame update
    void Start()
    {
        meshAgent.updateRotation = false;
        meshAgent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        SetDestination(trans.position);
        //meshAgent.SetDestination(trans.position);
    }

    private void SetDestination(Vector3 pos)
    {
        float agentOffset = 0.0001f;
        Vector3 agentPos = (Vector3)(agentOffset * Random.insideUnitCircle) + pos;
        meshAgent.SetDestination(agentPos);
    }
}
