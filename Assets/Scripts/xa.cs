using UnityEngine;
using System.Collections;

public class xa : MonoBehaviour 
{
	public static Ball ball;
	public static AudioManager audioManager;
	public static ScoreManager scoreManager;
	
	public static Player1 player1;
	public static Player2 player2;
	//public static Player3 player3;
	//public static Player4 player4;
	
	public static bool gameOver = false;
	
	// set to false if game is configured for CTF
	public static bool letsPlayKeepaway = true; 
	
	// layers
	public const int Team1Goal = 9;
	public const int Team2Goal = 10;


    public enum ButtonType { left, jump, right, none }
    public static ButtonType buttonType = ButtonType.none;

    void Start()
	{
		// cache these so they can be accessed by other scripts
        //ball = GameObject.FindWithTag("Ball").GetComponent<Ball>();
        //scoreManager = gameObject.GetComponent<ScoreManager>();
        //audioManager = gameObject.GetComponent<AudioManager>();
		player1 = GameObject.Find("Player1").GetComponent<Player1>();
        //player2 = GameObject.Find("Player2").GetComponent<Player2>();
		//player3 = GameObject.Find("Player3").GetComponent<Player3>();
		//player4 = GameObject.Find("Player4").GetComponent<Player4>();
	}

    void OnGUI()
    {
        Debug.Log("OnGUI");
        GUI.skin.button.normal.textColor = (buttonType == ButtonType.left) ? Color.yellow : Color.white;
        GUI.skin.button.hover.textColor = GUI.skin.button.normal.textColor;
        if (GUI.Button(new Rect(2, 2, 150, 30), "<<"))
        {
            buttonType = ButtonType.left;
        }
        GUI.skin.button.normal.textColor = (buttonType == ButtonType.jump) ? Color.yellow : Color.white;
        GUI.skin.button.hover.textColor = GUI.skin.button.normal.textColor;
        if (GUI.Button(new Rect(200, 2, 150, 30), "jump"))
        {
            buttonType = ButtonType.jump;
        }
        GUI.skin.button.normal.textColor = (buttonType == ButtonType.right) ? Color.yellow : Color.white;
        GUI.skin.button.hover.textColor = GUI.skin.button.normal.textColor;
        if (GUI.Button(new Rect(400, 2, 150, 30), ">>"))
        {
            buttonType = ButtonType.right;
        }
    }
}
