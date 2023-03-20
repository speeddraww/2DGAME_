using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemy;
    Animator animator;

    public float Health{
        set{
            _health = value;
            if(value < 0){
                animator.SetTrigger("hit");
            }
            if (_health <= 0){
                
                animator.SetTrigger("death");
            }
        }
        get{
            return _health;
        }
    }

    public float _health = 3;
    public void Start(){
        animator = GetComponent<Animator>();
    }
    
   void OnHit(float damage)
    {
        
        Health -= damage;
    }
}
