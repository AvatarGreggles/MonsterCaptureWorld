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
    bool inAction;

    Transform camera;

    Animator animator;

    CharacterController characterController;

    private void Awake()
    {
        camera = Camera.main.transform;
        animator = GetComponent<Animator>();

        characterController = GetComponent<CharacterController>();

    }

    private void Update()
    {
        if (inAction)
        {
            return;
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Run"))
        {
            isRunning = !isRunning;
        }

        if (Input.GetButtonDown("Roll"))
        {
            StartCoroutine(DoAction("Roll"));
        }

        float moveAmount = Mathf.Clamp01(Mathf.Abs(h) + Mathf.Abs(v));

        var moveInput = new Vector3(h, 0, v);
        float camYRotation = camera.rotation.eulerAngles.y;
        var moveDir = Quaternion.Euler(0, camYRotation, 0) * moveInput;
        float moveSpeed = isRunning ? runSpeed : walkSpeed;

        characterController.Move(moveDir * moveSpeed * Time.deltaTime);

        if (moveAmount > 0)
        {
            targetRotation = Quaternion.LookRotation(moveDir);
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, angularSpeed * Time.deltaTime);

        animator.SetFloat("moveAmount", moveAmount * moveSpeed / runSpeed, 0.2f, Time.deltaTime);
    }

    IEnumerator DoAction(string animName)
    {
        inAction = true;
        animator.CrossFade(animName, 0.2f);
        yield return null;

        var animState = animator.GetNextAnimatorStateInfo(0);

        float timer = 0f;

        while (timer <= animState.length)
        {
            timer += Time.deltaTime;

            if(animator.IsInTransition(0) && timer > 0.4f){
                break;
            }
            yield return null;
        }
   
        inAction = false;
    }
}
