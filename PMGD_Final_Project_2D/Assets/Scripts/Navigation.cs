using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navigation : MonoBehaviour
{
    public Transform target; // Target yang akan dijangkau
    private NavMeshAgent navMeshAgent; // Komponen NavMeshAgent

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>(); // Mendapatkan NavMeshAgent dari GameObject ini
        SetDestination(); // Menetapkan target awal
    }

    private void SetDestination()
    {
        if (target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z); // Mendapatkan posisi target pada ketinggian yang sama dengan GameObject ini
            navMeshAgent.SetDestination(targetPosition); // Menetapkan target posisi ke NavMeshAgent
        }
    }

    private void Update()
    {
        if (target != null && !navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.1f)
        {
            SetDestination(); // Menetapkan target baru jika target sebelumnya sudah tercapai
        }
    }
}
