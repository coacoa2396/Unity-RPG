using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Weapon weapon;

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

    public void EnableWeapon()
    {
        weapon.EnableWeapon();
    }

    public void DisableWeapon()
    {
        weapon.DisableWeapon();
    }

    void OnAttack(InputValue value)
    {
        Attack();
    }
}
