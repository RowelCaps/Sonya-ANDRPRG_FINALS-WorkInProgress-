using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour {

    [SerializeField] float jumpHeight = 10.5f;
    [SerializeField] float jumpSpeed = 10.0f;
    [SerializeField]private Joystick joystick;

    private CharacterController characterController;
    private float movementSpeed = 5f;
    private Animator anim;
    private bool isJump = false;

    private void Awake()
    {
        Assert.IsNotNull(joystick);
    }
    // Use this for initialization
    void Start () {

        characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
	}

    private void FixedUpdate()
    {
        move();
        if (isJump)
            jump();
    }

    private void move()
    {
        if (joystick.Direction != Vector3.zero)
        {
            anim.SetBool("IsWalking", true);
            characterController.SimpleMove(joystick.Direction * movementSpeed);

            Vector3 targetRotation = transform.position + joystick.Direction;
            Quaternion rotation = Quaternion.LookRotation(targetRotation - transform.position);
            transform.rotation = rotation;
            
        }
        else
            anim.SetBool("IsWalking", false);
    }

    public void SetJumpTrue()
    {
        isJump = true;
    }

    private void jump()
    {
        float startingHeight = 0f;
        bool hasJump = false;

        if (characterController.isGrounded && !hasJump)
        {
            startingHeight = transform.position.y;
            anim.Play("Jump");
            hasJump = true;
            characterController.Move(Vector3.up * jumpHeight);
        }

        if (transform.position.y > jumpHeight + startingHeight)
        {
            isJump = false;
            hasJump = false;
            return;
        }
    }
}
