using UnityEngine;
using System.Collections;

public class PickupLogic : MonoBehaviour 
{
	[SerializeField]
	private int pickupPoints = 1;				//awarded points for picking this up

	void OnTriggerEnter2D(Collider2D other)
	{
		//checks if the entered object is with tag, "Player"
		if (other.tag == "Player") {
			//searches scene for a ScoreManager class
			ScoreManager scoreManager = FindObjectOfType<ScoreManager> ();
			//applies score
			scoreManager.UpdateScore(pickupPoints);
			//destroy this gameobject
			Destroy (gameObject);
		}
	}
}
