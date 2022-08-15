using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float walkSpeed = 3f;
    [SerializeField] float runSpeed = 6f;

    [SerializeField] float angularSpeed = 500f;
    Quaternion targetRotation;

    bool isRunning = false;

    Transform camera;

    Animator animator;

    private void Awake()
    {
        camera = Camera.main.transform;
        animator = GetComponent<Animator>();

    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Run"))
        {
            isRunning = !isRunning;
        }

        float moveAmount = Mathf.Clamp01(Mathf.Abs(h) + Mathf.Abs(v));

        var moveInput = new Vector3(h, 0, v);
        float camYRotation = camera.rotation.eulerAngles.y;
        var moveDir = Quaternion.Euler(0, camYRotation, 0) * moveInput;
        float moveSpeed = isRunning ? runSpeed : walkSpeed;

        transform.position += moveDir * moveSpeed * Time.deltaTime;

        if (moveAmount > 0)
        {
            targetRotation = Quaternion.LookRotation(moveDir);
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, angularSpeed * Time.deltaTime);

        animator.SetFloat("moveAmount", moveAmount * moveSpeed / runSpeed, 0.2f, Time.deltaTime);
    }
}
