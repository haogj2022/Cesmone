using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Nguyen Anh Hao
//Date created: 16/11/2022
//Summary: Main Camera follows player

public class CameraFollow : MonoBehaviour
{
    GameObject follower;
    public CastleHealth castle;
    public CompositeCollider2D mapBounds;

    private float xMin, xMax, yMin, yMax;
    private float camX, camY;
    private float camOrthsize;
    private Camera mainCam;

    private float smoothSpeed = 0.01f;

    public BoxCollider2D topWall;
    public BoxCollider2D bottomWall;
    public BoxCollider2D leftWall;
    public BoxCollider2D rightWall;

    private void Start()
    {
        follower = GameObject.Find("Hero Selection");
        castle.GetComponent<CastleHealth>();

        xMin = mapBounds.bounds.min.x - 4;
        xMax = mapBounds.bounds.max.x + 4;
        yMin = mapBounds.bounds.min.y;
        yMax = mapBounds.bounds.max.y;

        mainCam = GetComponent<Camera>();
        camOrthsize = mainCam.orthographicSize;
    }

    private void Update()
    {
        CheckWalls();

        if (castle.currentHealth <= 0)
        {
            follower = GameObject.Find("Castle");
        }

        camY = Mathf.Clamp(follower.transform.position.y, yMin + camOrthsize, yMax - camOrthsize);
        camX = Mathf.Clamp(follower.transform.position.x, xMin + camOrthsize, xMax - camOrthsize);

        transform.position = Vector3.Lerp(transform.position, new Vector3(camX, camY, transform.position.z), smoothSpeed);
    }

    void CheckWalls()
    {
        topWall.offset = new Vector2(0, mainCam.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y - 1.5f);

        bottomWall.offset = new Vector2(0, mainCam.ScreenToWorldPoint(new Vector3(0, 0, 0)).y);

        leftWall.offset = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(0, 0, 0)).x, 0);

        rightWall.offset = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x, 0);
    }
}
