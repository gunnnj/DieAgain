using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator animator;
    private Vector3 dir;
    private bool isDie = false;
    public bool canJump = true;
    public AudioSource jumpSound;
    public AudioSource deadSound;
    [SerializeField] private VariableJoystick joystick;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float rotateSpeed= 10f;
    [SerializeField] private float jumpForce = 1000f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(!isDie){
            MoveAndRotate();
            if(Input.GetKeyDown(KeyCode.Space)){
                Jump();
            }
        }  
    }

    public void Jump()
    {
        if(canJump){
            jumpSound.Play();
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            animator.SetBool("IsJump",true);
            canJump = false;
        }
    }

    private void MoveAndRotate()
    {
        float dirX = joystick.Horizontal;
        float dirZ = joystick.Vertical;
      
        dir = new Vector3 (dirX,0, dirZ);

        if(dir.magnitude>0){

            Rotate();
            Move();
            SetAnimMove(true);
        }
        else{
            SetAnimMove(false);
        }
    }

    private void Move()
    {
        Vector3 newPos = dir + transform.position;
        transform.position = Vector3.Lerp(transform.position,newPos,speed*Time.deltaTime);
    }

    public void Rotate(){
        Vector3 rotate = Vector3.RotateTowards(transform.forward,dir,rotateSpeed*Time.deltaTime,0f);
        transform.rotation = Quaternion.LookRotation(rotate);
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Kill")){
            Dead();
        }
    }
    public void Dead(){
        deadSound.Play();
        animator.SetBool("Die2",true);
        isDie = true;
        SceneFade.Instance.FadeToScene("SceneEnd");
    }

    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground")){
            animator.SetBool("IsJump",false);
        }
    }
    public void OnCollisionStay(Collision other)
    {
        if(other.gameObject.CompareTag("Ground")){       
            canJump = true;
        }
    }

    public void OnCollisionExit(Collision other)
    {
        if(other.gameObject.CompareTag("Ground")){
            canJump = false;
        }
    }

    public void SetAnimMove(bool blval){
        animator.SetBool("IsMove",blval);
    }

}
