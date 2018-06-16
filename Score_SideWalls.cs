using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score_SideWalls : MonoBehaviour {

    public BallControl ballcontrol;
    static int playerScore01 = 0;
    static int playerScore02 = 0;
    public string wallName;
    public GUISkin ScoreSkin;
    public Transform buttonReset;

    void Start()
    {
        ballcontrol = FindObjectOfType(typeof(BallControl)) as BallControl;
        buttonReset = GameObject.Find("Ball").transform;
    }


    // Use this function on trigger - wall hit with ball
    void OnTriggerEnter2D ( Collider2D hitInfo ) {
        AudioSource audio = GetComponent<AudioSource>();
        if (hitInfo.name == "Ball")
            audio.Play();
        {
            if (wallName == "rightWall")
            {
                playerScore01 += 1;
            }
            else
            {
                playerScore02 += 1;
            }
            Debug.Log("Player01 Score is " + playerScore01);
            Debug.Log("Player02 Score is " + playerScore02);

            hitInfo.gameObject.SendMessage("Reset_balls");
            //ballcontrol.Reset_balls();
        }
		
	}

    void OnGUI()
    {
        GUI.skin = ScoreSkin;
        GUI.Label(new Rect(Screen.width / 2 - 150-18, 25, 100, 100), "" + playerScore01);
        GUI.Label(new Rect(Screen.width / 2 + 150-18, 25, 100, 100), "" + playerScore02);

        if (GUI.Button ( new Rect (Screen.width / 2 -121/1.8f, 25, 121, 53), "RESET"))
        {
            //Comment for old call - new option is reset whole scene
            playerScore01 = 0;
            playerScore02 = 0;
            //buttonReset.SendMessage("Reset_balls");
            SceneManager.LoadScene("GamePlay");
        }
    }
}
