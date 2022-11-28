using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Nguyen Anh Hao
//Date created: 15/11/2022
//Summary: Move character to touch position

public class TouchAndGo : MonoBehaviour
{
    private Camera cam;
    private float moveSpeed = 0.05f;
    private float startTime;
    private float journeyDistance;
    Vector3 point = new Vector3();

    public Animator[] animators;

    public bool canMove = false;
    private bool facingRight = true;

    private void Start()
    {
        cam = Camera.main;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Castle")
        {
            Vector2 direction = (transform.position - point).normalized;
            point = new Vector2(transform.position.x + direction.x, transform.position.y + direction.y);
        }
    }

    private void Update()
    {
        CharacterMove();        
    }

    private void CharacterMove()
    {
        if (canMove)
        {
            if (Input.GetMouseButtonDown(0))
            {                
                Vector3 mousePos = Input.mousePosition;

                startTime = Time.time;
                point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));                
            }

            journeyDistance = Vector3.Distance(transform.position, point);

            // Distance moved equals elapsed time times speed..
            float distCovered = (Time.time - startTime) * moveSpeed;

            // Fraction of journey completed equals current distance divided by total distance.
            float fractionOfJourney = distCovered / journeyDistance;

            if (transform.position != point)
            {
                foreach(Animator anim in animators)
                {
                    anim.SetTrigger("isRunning");
                }

                transform.position = Vector3.Lerp(transform.position, point, fractionOfJourney);
            }

            if (journeyDistance < 0.01f)
            {
                transform.position = point;

                foreach (Animator anim in animators)
                {
                    anim.SetTrigger("isIdling");
                }
            }

            Vector2 direction = (transform.position - point).normalized;

            if (direction.x > 0 && facingRight)
            {
                Flip();
            }

            if (direction.x < 0 && !facingRight)
            {
                Flip();
            }
        }                
    }

    void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;

        facingRight = !facingRight;
    }
}

