using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSetup : MonoBehaviour {

    // variables
    public Camera mainCam;
    public BoxCollider2D topWall;
    public BoxCollider2D bottomWall;
    public BoxCollider2D leftWall;
    public BoxCollider2D rightWall;
    public Transform Player01;
    public Transform Player02;

    // if the screen size will be changed during a playsession
    void Start () {

        //Move each wall to its edge location
        topWall.size = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(Screen.width * 2f, 0f, 0f)).x, 1f);
        topWall.offset = new Vector2(0f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y + 0.5f);

        bottomWall.size = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(Screen.width * 2f, 0f, 0f)).x, 1f);
        bottomWall.offset = new Vector2(0f, mainCam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).y - 0.5f);

        leftWall.size = new Vector2(1f ,mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y);
        leftWall.offset = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x - 0.5f, 0f);

        rightWall.size = new Vector2(1f ,mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y);
        rightWall.offset = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x + 0.5f, 0f);

        //Move the players to a fixed distance from the edges of the screen:
        Vector3 tempVec_01 = Vector3.zero;
        tempVec_01 = Player01.position;
        tempVec_01.x = mainCam.ScreenToWorldPoint(new Vector3(75f, 0f, 0f)).x;
        Player01.position = tempVec_01;

        Vector3 tempVec_02 = Vector3.zero;
        tempVec_02 = Player02.position;
        tempVec_02.x = mainCam.ScreenToWorldPoint(new Vector3(Screen.width - 75f, 0f, 0f)).x;
        Player02.position = tempVec_02;
    }

    // OPEN MENU Scene when ESC is pressed
    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("pong_menu");
        }
    }
}
