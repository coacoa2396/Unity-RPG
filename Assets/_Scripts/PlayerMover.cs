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
        fowardDir = new Vector3(fowardDir.x, 0, fowardDir.z).normalized;      // 방향을 구하고 싶으면 normalized

        Vector3 rightDir = Camera.main.transform.right;
        rightDir = new Vector3(rightDir.x, 0, rightDir.z).normalized;

        controller.Move(fowardDir * moveDir.z * moveSpeed * Time.deltaTime);
        controller.Move(rightDir * moveDir.x * moveSpeed * Time.deltaTime);

        Vector3 lookDir = fowardDir * moveDir.z + rightDir * moveDir.x;
        if (lookDir.sqrMagnitude > 0)   // if(lookDir != Vector3.zero) 요 방법이 최적화가 더 좋다
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

        animator.SetFloat("MoveSpeed", moveDir.magnitude);          // 크기(속력, 스칼라)를 구하고 싶으면 magnitude
    }
    //                                                              // 크기와 방향을 다 가지고 있으면 Vector(속도)
    //                                                              // 다만 이제 속력을 비교하고 싶은 경우에는 magnitude 대신
    //                                      5

// Vector의 투영
// Vector3.Project 혹은 평면인 경우 Vector3.ProjectOnPlane 쓰기