using UnityEngine;
using System.Collections;
/*
[RequireComponent(typeof(Rigidbody2D))]
public class PlatformController : MonoBehaviour 
{
	[Header("Movement Settings:")]
	[SerializeField]
	private float movementSpeed = 5;
	[Space]
	[Header("Jump Settings:")]
	[SerializeField]
	private Transform groundChecker;
	[SerializeField]
	private float jumpPower = 10.0f;
	[SerializeField]
	private float distanceToGround = 0.5f;
	[SerializeField]
	private float downAccel = 1f;
	[SerializeField]
	private LayerMask ground;

	private Rigidbody2D rb;
	private RaycastHit2D hit;
	private Vector2 velocity = Vector2.zero;
	private Vector2 direction = Vector2.zero;
	private float jumpDirection = 1;
	private float xInput = 0;
	private float downwardMovement = 0;
	private bool jumpPressed = false;
	
	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
		direction = Vector2.down;
	}

	void Update () 
	{
		xInput = Input.GetAxisRaw ("Horizontal");
		jumpPressed = Input.GetButtonDown ("Jump");

		JumpLogic ();
		GravityRotate ();

		velocity = Vector2.ClampMagnitude (velocity, 1).normalized * movementSpeed;
	}

	void FixedUpdate()
	{
		if (velocity != Vector2.zero) {
			rb.velocity = velocity * Time.fixedDeltaTime;
		}
	}
	
	void GravityRotate()
	{
		if (GravityMagic.State == GravityMagic.GravityState.UP) {
			velocity.x = xInput * GravityMagic.GravityMultipler;
			direction = Vector2.up;
			jumpDirection = -1;
			rb.rotation = -180;
		}
		else if (GravityMagic.State == GravityMagic.GravityState.DOWN) {
			velocity.x = xInput * GravityMagic.GravityMultipler;
			direction = Vector2.down;
			jumpDirection = 1;
			rb.rotation = 0;
		}
		else if (GravityMagic.State == GravityMagic.GravityState.LEFT) {
			velocity.y = xInput * GravityMagic.GravityMultipler;
			direction = Vector2.left;
			jumpDirection = 1;
			rb.rotation = -90;
		}
		else if (GravityMagic.State == GravityMagic.GravityState.RIGHT) {
			velocity.y = xInput * GravityMagic.GravityMultipler;
			direction = Vector2.right;
			jumpDirection = -1;
			rb.rotation = 90;
		}
	}
	
	void JumpLogic()
	{
		if (Grounded () && jumpPressed) {
			if (GravityMagic.Reverse == false) {
				rb.AddForce(new Vector2(0, jumpPower * jumpDirection));
			} else {
				rb.AddForce(new Vector2(jumpPower * jumpDirection, 0));
			}
			velocity = Vector2.zero;
		}
	}

	bool Grounded()
	{
		hit = Physics2D.Raycast (rb.position, direction, distanceToGround, ground);
		Debug.Log (hit.distance);
		if(hit.collider != null) {
			return true;
		}
		Debug.Log ("Not grounded");
		return false;
	}
}
*/