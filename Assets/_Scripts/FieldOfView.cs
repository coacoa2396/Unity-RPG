using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] float range;
    [SerializeField] float angle;
    [SerializeField] LayerMask targetMask;
    [SerializeField] LayerMask obsticleMask;

    private void Update()
    {
        FindTarget();
    }

    Collider[] colliders = new Collider[20];
    void FindTarget()
    {
        // 1. ���� ���� �ִ°�?
        int size = Physics.OverlapSphereNonAlloc(transform.position, range, colliders, targetMask);
        for (int i = 0; i < size; i++)
        {
            // 2. ���� ���� �ִ°�?
            Vector3 dirToTarget = (colliders[i].transform.position - transform.position).normalized;
            if (Vector3.Dot(transform.forward, dirToTarget) < Mathf.Cos(angle * 0.5f * Mathf.Deg2Rad))
                continue;

            // 3. �߰��� ��ֹ��� �ִ°�?
            float distanceToTarget = Vector3.Distance(transform.position, colliders[i].transform.position);
            if (Physics.Raycast(transform.position, dirToTarget,distanceToTarget, obsticleMask))
                continue;

            // �� �� �ִ�.
            Debug.DrawRay(transform.position, dirToTarget * distanceToTarget, Color.red);
        }
    }

}
