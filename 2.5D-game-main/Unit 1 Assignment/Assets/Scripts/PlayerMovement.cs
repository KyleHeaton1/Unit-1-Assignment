using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Stats")]
    public float moveSpeed;
	public float jumpHeight;
    public GameObject playerModel;
    public GameObject thePlayer;
	private bool isGrounded;
    private Rigidbody myRB;
    private Vector3 change;
	private Vector3 jumpVector;
    Animator playerAnimation;
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
		jumpVector = new Vector3(0.0f,1.0f,0.0f);
        playerAnimation = playerModel.GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        change = Vector3.zero;
        change.x =Input.GetAxisRaw("Horizontal");
        if(change != Vector3.zero){
            MovePlayer();
        }
        else{
            playerAnimation.SetBool("IsRunning", false);
        }
		if(Input.GetKey(KeyCode.Space) && isGrounded){
			Jump();
		}
        Vector2 mousePos = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
        var playerScreenPoint = Camera.main.WorldToScreenPoint(thePlayer.transform.position);
        if(mousePos.x < playerScreenPoint.x){
            Helper.FlipPlayer(thePlayer, true);
        }
        else{
            Helper.FlipPlayer(thePlayer, false);
        }
    }
    void MovePlayer(){
        myRB.MovePosition(transform.position + change * moveSpeed * Time.deltaTime);
        playerAnimation.SetBool("IsRunning", true);
    }
	void Jump(){
		 myRB.AddForce(jumpVector* jumpHeight, ForceMode.Impulse);
		 isGrounded = false;
	}
	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Ground"){
			isGrounded = true;
            myRB.velocity = Vector3.zero;
            myRB.angularVelocity = Vector3.zero;
		}
	}
    void OnCollisionExit(Collision other) {
     if(other.gameObject.tag == "Ground"){
         isGrounded = false;
     }   
    }
}