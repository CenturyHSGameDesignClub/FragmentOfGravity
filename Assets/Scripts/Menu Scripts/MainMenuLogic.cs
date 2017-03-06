using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuLogic : MonoBehaviour 
{
	//attached to a button - starts the game
	public void Play()
	{
		SceneManager.LoadScene ("Test_Arena");
	}

	//attached to a button - quits the game
	public void Quit()
	{
		Application.Quit ();
	}
}
