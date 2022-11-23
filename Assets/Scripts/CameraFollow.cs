using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Nguyen Anh Hao
//Date created: 16/11/2022
//Summary: Main Camera follows player

public class CameraFollow : MonoBehaviour
{
    public Transform followTransform;
    public CompositeCollider2D mapBounds;

    private float xMin, xMax, yMin, yMax;
    private float camX, camY;
    private float camOrthsize;
    private Camera mainCam;

    private float smoothSpeed = 0.01f;

    private void Start()
    {
        xMin = mapBounds.bounds.min.x - 4;
        xMax = mapBounds.bounds.max.x + 4;
        yMin = mapBounds.bounds.min.y;
        yMax = mapBounds.bounds.max.y;
        mainCam = GetComponent<Camera>();
        camOrthsize = mainCam.orthographicSize;
    }

    private void Update()
    {
        camY = Mathf.Clamp(followTransform.position.y, yMin + camOrthsize, yMax - camOrthsize);
        camX = Mathf.Clamp(followTransform.position.x, xMin + camOrthsize, xMax - camOrthsize);

        transform.position = Vector3.Lerp(transform.position, new Vector3(camX, camY, transform.position.z), smoothSpeed);
    }
}
