using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MoreMountains.CorgiEngine;

public class CutsceneConversationManager : MonoBehaviour {

	public GameObject RebelPanel;
	public GameObject BunnyPanel;
	private int _partOfConversation = 1;
	public GameObject RebelPortrait;
	public GameObject BunnyPortrait;
	public GameObject Spacebar;
	private Vector3 _bunnyStartPosition;
	private Vector3 _rebelStartPosition;


	void Start()
	{
		_bunnyStartPosition = BunnyPortrait.transform.position;
		_rebelStartPosition = RebelPortrait.transform.position;
	}

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Space)) {
			Conversation ();
			_partOfConversation++;
		}
	}

	void Conversation ()
	{
		switch (_partOfConversation)
		{
		case 1:
			Spacebar.SetActive (false);
			RebelPanel.SetActive (true);
			RebelPortrait.SetActive (true);
			RebelPortrait.transform.position = Vector3.Lerp (new Vector3 (_rebelStartPosition.x,_rebelStartPosition.y - 15, _rebelStartPosition.z), _rebelStartPosition, 1);
			break;
		case 2:
			RebelPanel.SetActive (false);
			RebelPortrait.SetActive (false);
			BunnyPortrait.SetActive (true);
			BunnyPanel.SetActive (true);
			BunnyPortrait.transform.position = Vector3.Lerp (new Vector3 (_bunnyStartPosition.x,_bunnyStartPosition.y - 15, _bunnyStartPosition.z), _bunnyStartPosition, 1);
			break;
		case 3:
			LoadingSceneManager.LoadScene ("Frog Forest");
			break;
		}
	}
}
