using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
	public float smoothSpeed = 1;

	private Transform target;
	private Vector2 followVelocity;

	void Start () 
	{
		SetToPlayer ();
	}

	void LateUpdate () 
	{
		if(transform.position != new Vector3(target.position.x, target.position.y, -10)) {
			transform.position = new Vector3(target.position.x, target.position.y, -10);
		}
	}

	public void SetToPlayer()
	{
		target = GameObject.FindGameObjectWithTag ("Player").transform;

		if (target == null) {
			Debug.LogError ("Target not found in SetToPlayer.");
		}
	}

	public void SetToCutScene(Transform target)
	{
		this.target = target;

		if (target == null) {
			Debug.LogError ("Target not found in SetToCutscene.");
		}
	}
}
