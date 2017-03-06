using UnityEngine;
using System.Collections;

public class GravityMagic : MonoBehaviour 
{
	//represents the current gravity direction
	public enum GravityState {
		UP,
		DOWN,
		LEFT,
		RIGHT
	}

	public static GravityState State;							//allows outside classes to recognize the current direction of gravity
	public static bool Reverse;									//easier for outside classes to effect only one axis
	public static float GravityMultipler;						//the current gravity multipler that effects other classes velocity calculation

	[SerializeField]
	private Vector2 gravityUp = new Vector2(0, 9.81f);
	[SerializeField]
	private Vector2 gravityDown = new Vector2(0, -9.81f);
	[SerializeField]
	private Vector2 gravityLeft = new Vector2(-9.81f, 0);
	[SerializeField]
	private Vector2 gravityRight = new Vector2(9.81f, 0);
	[SerializeField]
	private float gravityUpMultipler = 1;
	[SerializeField]
	private float gravityDownMultipler = 1;
	[SerializeField]
	private float gravityLeftMultipler = -1;
	[SerializeField]
	private float gravityRightMultipler = 1;

	void Start()
	{
		State = GravityState.DOWN;
		Reverse = false;
		GravityMultipler = 1;
	}

	void Update () 
	{
		ChangeDirection ();
	}

	//changes the state and direction of gravity by input
	void ChangeDirection()
	{
		//changes to the left direction
		if(Input.GetKeyDown(KeyCode.LeftArrow)) {
			State = GravityState.LEFT;
			//changes to the right direction
		} else if(Input.GetKeyDown(KeyCode.RightArrow)) {
			State = GravityState.RIGHT;
			//changes to the up direction
		} else if(Input.GetKeyDown(KeyCode.UpArrow)) {
			State = GravityState.UP;
			//changes to the down direction
		} else if(Input.GetKeyDown(KeyCode.DownArrow)) {
			State = GravityState.DOWN;
		}
	}

	void FixedUpdate()
	{
		//changes the physics for outside classes
		CalculatePhysics ();
	}

	void CalculatePhysics()
	{
		switch (State) {
		case GravityState.UP:
			GravityMultipler = gravityUpMultipler;
			Reverse = false;
			Physics2D.gravity = gravityUp;
			break;
		case GravityState.DOWN:
			GravityMultipler = gravityDownMultipler;
			Reverse = false;
			Physics2D.gravity = gravityDown;
			break;
		case GravityState.LEFT:
			GravityMultipler = gravityLeftMultipler;
			Reverse = true;
			Physics2D.gravity = gravityLeft;
			break;
		case GravityState.RIGHT:
			GravityMultipler = gravityRightMultipler;
			Reverse = true;
			Physics2D.gravity = gravityRight;
			break;
		}
	}
}
