using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] Animator animator;
    [SerializeField] float moveSpeed;

    Vector3 moveDir;

    private void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 fowardDir = Camera.main.transform.forward;
        fowardDir = new Vector3(fowardDir.x, 0, fowardDir.z).normalized;      // ������ ���ϰ� ������ normalized

        Vector3 rightDir = Camera.main.transform.right;
        rightDir = new Vector3(rightDir.x, 0, rightDir.z).normalized;

        controller.Move(fowardDir * moveDir.z * moveSpeed * Time.deltaTime);
        controller.Move(rightDir * moveDir.x * moveSpeed * Time.deltaTime);

        Vector3 lookDir = fowardDir * moveDir.z + rightDir * moveDir.x;
        if (lookDir.sqrMagnitude > 0)   // if(lookDir != Vector3.zero) �� ����� ����ȭ�� �� ����
        {
            Quaternion lookRotation = Quaternion.LookRotation(lookDir);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 10);
        }
    }

    void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        moveDir.x = input.x;
        moveDir.z = input.y;

        animator.SetFloat("MoveSpeed", moveDir.magnitude);          // ũ��(�ӷ�, ��Į��)�� ���ϰ� ������ magnitude
    }
    //                                                              // ũ��� ������ �� ������ ������ Vector(�ӵ�)
    //                                                              // �ٸ� ���� �ӷ��� ���ϰ� ���� ��쿡�� magnitude ���
    //                                      5

// Vector�� ����
// Vector3.Project Ȥ�� ����� ��� Vector3.ProjectOnPlane ����