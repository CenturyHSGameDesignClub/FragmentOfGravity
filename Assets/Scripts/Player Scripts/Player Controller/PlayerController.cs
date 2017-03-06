using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))] 			//forces this component to have a rigidbody2D
public class PlayerController : MonoBehaviour 
{
	[Header("Input Settings:")]
	[SerializeField]
	private string xInputAxis = "Horizontal";
	[SerializeField]
	private float axisInputDeadzone = 0.2f;
	[SerializeField]
	private string jumpButton = "Jump";
	[Space]
	[Header("Movement Settings:")]
	[SerializeField]
	private float movementSpeed = 5;				//alters speed of movement
	[Space]
	[Header("Jump Settings:")]
	[SerializeField]
	private float jumpPower = 10.0f;				//force applied to the rigidbody as a jump
	[Space]
	[Header("Grounded Settings:")]
	[SerializeField]
	private float groundedRadius = 0.5f;			//radius of a circlur cast for checking if player is grounded
	[SerializeField]
	private LayerMask groundLayer;					//physics layers that count as the ground

	private Rigidbody2D rb;							
	private Transform groundCheck;					
	private Vector2 velocity = Vector2.zero;
	private float xInput = 0;
	private bool jumpPressed = false;
	private bool isGrounded = false;

	void Start () 
	{
		//searches this gameobject for a rigidbody2D component
		rb = GetComponent<Rigidbody2D> ();
		//searches this gameobject for a child with the name, "GroundCheck"
		groundCheck = transform.Find ("GroundCheck");
	}

	void Update () 
	{
		GetInput ();
		JumpLogic ();
		SetVelocity ();
	}

	void FixedUpdate()
	{
		Grounded ();
		ApplyPhysics ();
	}

	void GetInput()
	{
		xInput = Input.GetAxis (xInputAxis);
		jumpPressed = Input.GetButtonDown (jumpButton);
	}

	void SetVelocity()
	{
		//checks if input overcomes deadzone
		if (Mathf.Abs (xInput) > axisInputDeadzone) {
			//sets x-axis of velocity to the input
			velocity.x = xInput;
			//clamps it so diagonal movement is not a bonus
			velocity = Vector2.ClampMagnitude (velocity, 1).normalized * movementSpeed;
		} else {
			velocity = Vector2.zero;
		}
	}

	void JumpLogic()
	{	
		//checks if player is on the ground and press the jump key
		if (isGrounded && jumpPressed) {
			//apply a force to the player
			rb.AddForce(new Vector2(0, jumpPower));
		}
	}

	void Grounded()
	{
		//sets grounded to false and sets it back to true
		isGrounded = false;

		//gets all colliders in circlur cast
		Collider2D[] colliders = Physics2D.OverlapCircleAll (groundCheck.position, groundedRadius, groundLayer); 
		for (int i = 0; i < colliders.Length; i++)
		{
			//checks if none of the gameobjects that was hit is not this
			if (colliders [i].gameObject != gameObject) {
				isGrounded = true;
			}
		}
	}

	//sets the rigidbody reference to the calculated velocity
	void ApplyPhysics()
	{
		rb.velocity = new Vector2(velocity.x, rb.velocity.y);
	}
}
