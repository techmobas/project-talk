using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //Init
    [SerializeField]private float runSpeed;

    //References 
    private Vector2 moveInput;
    private Rigidbody2D rb2;

    private void Start(){
        rb2 = GetComponent<Rigidbody2D>();
    }

    private void Update(){
        Run();
    }

    private void OnMove(InputValue value){
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }

    private void Run(){
        Vector2 playerVelocity = new Vector2 (moveInput.x * runSpeed, rb2.velocity.y);
        rb2.velocity = playerVelocity;
    }
}
