using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //Init
    [SerializeField]private GameObject interactIcon;
    [SerializeField]private float runSpeed;

    //References 
    private Vector2 moveInput;
    private Rigidbody2D rb2;

    private Vector2 boxSize = new Vector2(0.1f, 1f);

    private void Start(){
        interactIcon.SetActive(false);
        rb2 = GetComponent<Rigidbody2D>();
    }

    private void Update(){
        Run();
        FlipSprite();
    }

    private void OnMove(InputValue value){
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }

    private void OnInteract(InputValue value){
        if(value.isPressed){
            CheckInteraction();
        }
    }

    private void Run(){
        Vector2 playerVelocity = new Vector2 (moveInput.x * runSpeed, rb2.velocity.y);
        rb2.velocity = playerVelocity;
    }

    private void FlipSprite(){
        bool playerHorizontal = Mathf.Abs(rb2.velocity.x) > Mathf.Epsilon;
        if (playerHorizontal){
            transform.localScale = new Vector2(Mathf.Sign(rb2.velocity.x), 1f);
        }
    }

    public void OpenInteractIcon(){
        interactIcon.SetActive(true);
    }

    public void CloseInteractIcon(){
        interactIcon.SetActive(false);
    }

    private void CheckInteraction(){
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, boxSize, 0, Vector2.zero);

        if (hits.Length > 0){
            foreach(RaycastHit2D rc in hits){
                if (rc.IsInteractable()){
                    rc.Interact();
                }
            }
        }

    }
}
