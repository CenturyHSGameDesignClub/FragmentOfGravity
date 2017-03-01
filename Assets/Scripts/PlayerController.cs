using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	[Header("Movement Settings:")]
	[SerializeField]
	private float movementSpeed = 5;
	[Space]
	[Header("Jump Settings:")]
	[SerializeField]
	private float jumpPower = 10.0f;
	[Space]
	[Header("Grounded Settings:")]
	[SerializeField]
	private Transform groundCheck;
	[SerializeField]
	private float groundedRadius = 0.5f;
	[SerializeField]
	private LayerMask ground;

	private Rigidbody2D rb;
	private Vector2 velocity = Vector2.zero;
	private float xInput = 0;
	private bool jumpPressed = false;
	private bool isGrounded = false;

	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
	}

	void Update () 
	{
		xInput = Input.GetAxisRaw ("Horizontal");
		jumpPressed = Input.GetButtonDown ("Jump");

		JumpLogic ();
		velocity.x = xInput;

		velocity = Vector2.ClampMagnitude (velocity, 1).normalized * movementSpeed;
	}

	void FixedUpdate()
	{
		Grounded ();

		if (velocity != Vector2.zero) {
			rb.velocity = new Vector2(velocity.x, rb.velocity.y);
		}
	}

	void JumpLogic()
	{
		if (isGrounded && jumpPressed) {
			rb.AddForce(new Vector2(0, jumpPower));
		}
	}

	void Grounded()
	{
		isGrounded = false;

		Collider2D[] colliders = Physics2D.OverlapCircleAll (groundCheck.position, groundedRadius, ground); 
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders [i].gameObject != gameObject) {
				isGrounded = true;
			}
		}
	}
}
