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
        controller.Move(moveDir * moveSpeed * Time.deltaTime);
    }

    void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        moveDir.x = input.x;
        moveDir.z = input.y;

        animator.SetFloat("MoveSpeed", moveDir.magnitude);
    }
}
