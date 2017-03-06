using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerGUIManager : MonoBehaviour 
{
	[SerializeField]
	private Transform playerGUIPrefab;						//reference to playerGUI prefab

	private Transform playerGUI;							//instantiate reference for GUI prefab
	public static Text ScoreText;							
	public static GameObject WinText;

	void Awake()
	{
		playerGUI = Instantiate (playerGUIPrefab).transform;
		ScoreText = playerGUI.Find ("ScoreBackgroundPanel").FindChild ("ScoreText").GetComponent<Text> ();
		WinText = playerGUI.Find ("WinText").gameObject;
	}

	void Start()
	{
		WinText.SetActive (false);
	}
}
