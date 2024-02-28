using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttacker : MonoBehaviour
{

    [SerializeField] Animator animator;
    [SerializeField] Weapon weapon;
    [SerializeField] LayerMask layerMask;
    [SerializeField] float range;
    [SerializeField] float angle;
    [SerializeField] int damage;

    float cosRange;

    private void Awake()
    {
        cosRange = Mathf.Cos(Mathf.Deg2Rad * angle);
    }

    void Attack()
    {
        int rand = Random.Range(0, 2);
        if (rand == 0)
        {
            animator.SetTrigger("Attack1");
        }
        else
        {
            animator.SetTrigger("Attack2");
        }
    }

    // 공격범위 안에 있는 것들을 공격하기
    Collider[] colliders = new Collider[20];
    void AttackTiming()
    {
        int size = Physics.OverlapSphereNonAlloc(transform.position, range, colliders, layerMask);
        for (int i = 0; i < size; i++)
        {
            Vector3 dirToTarget = (colliders[i].transform.position - transform.position).normalized;
            
            //if (Vector3.Angle(transform.forward, dirToTarget) > 90)   // Angle은 연산이 좀 느리다
             //   continue;

            if (Vector3.Dot(transform.forward, dirToTarget) < cosRange)    // 내적은 연산이 빠르다
                continue;

            IDamagable damagable = colliders[i].GetComponent<IDamagable>();
            damagable?.TakeDamage(damage);
        }
    }


    /* 무기의 트리거 콜라이더 사용
    public void EnableWeapon()
    {
        weapon.EnableWeapon();
    }

    public void DisableWeapon()
    {
        weapon.DisableWeapon();
    }
    */
    void OnAttack(InputValue value)
    {
        Attack();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

