using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Takes and handles input and movement for a player character
public class PlayerController : MonoBehaviour
{
   public float moveSpeed = 1f;
   public float maxSpeed = 8f;

   public float idleFriction = 0.9f;
   public GameObject swordHitbox;

    Rigidbody2D rb;

    Animator animator;

    SpriteRenderer spriteRenderer;

    Collider2D swordCollider;

      Vector2 moveInput = Vector2.zero;

    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    
    bool isMoving = false;

    
  
    
    bool IsMoving{
        set{
            isMoving = value; // Establece el valor de la variable "isMoving" con el valor proporcionado en la propiedad "IsMoving"
            animator.SetBool("isMoving",isMoving ); //Actualiza el valor del parámetro de animación "isMoving" en el componente "animator" con el valor de la variable "isMoving"

        }
    }
    
    
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        swordCollider = swordHitbox.GetComponent<Collider2D>();
    }

    private void FixedUpdate() {
      if(canMove == true && moveInput != Vector2.zero){
        rb.velocity = Vector2.ClampMagnitude(rb.velocity + (moveInput * moveSpeed * Time.deltaTime),maxSpeed);
        if(moveInput.x > 0){
            spriteRenderer.flipX = false; 
        }else if (moveInput.x < 0){
            spriteRenderer.flipX = true;
        }
        IsMoving = true;

      }else {
        //rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero,idleFriction);
        IsMoving = false;
      }
      
    }



    void OnMove(InputValue value) {
        moveInput = value.Get<Vector2>();
    }

    void OnFire(){
      animator.SetTrigger("swordAttack");
    }



      
      

    
    
   
      //void LockMovement(){
        //canMove = false;
      //}
      //void UnlockMovement(){
        //canMove = true;
      //}
}
