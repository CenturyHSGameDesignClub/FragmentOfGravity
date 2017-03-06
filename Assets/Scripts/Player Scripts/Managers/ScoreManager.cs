using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour 
{
	[SerializeField]
	private int winScore = 3;								//required score to win the game
	[SerializeField]
	private int quitCountdown = 3;							//time before quitting game or loading to main menu

	private int score = 0;
	private bool startedCountdown = false;

	void Start () {
		score = 0;
		//sets GUI score to current
		PlayerGUIManager.ScoreText.text = "Score: " + score;
	}

	public void UpdateScore(int points)
	{
		score += points;

		//sets GUI score to current
		PlayerGUIManager.ScoreText.text = "Score: " + score;

		//checks if more points to win are aquired and hasn't started all ready
		if (score >= winScore && !startedCountdown) {
			startedCountdown = true;
			StartCoroutine ("Victory");
		}
	}

	IEnumerator Victory()
	{
		//activates winText gameobject
		PlayerGUIManager.WinText.SetActive (true);
		//pauses
		yield return new WaitForSeconds (quitCountdown);
		//exits game
		Application.Quit ();
	}
}
