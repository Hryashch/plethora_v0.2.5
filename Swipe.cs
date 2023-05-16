using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    //[SerializeField] private BoxCollider2D area1;

    public static event OnSwipeInput SwipeEvent;
    public delegate void OnSwipeInput(Vector2 direction,bool side);

    public static event OnSwipeInput SwipeEvent2;

    private Vector2 tapPosition;
    private Vector2 tapPosition2;
    private Vector2 delta;
    private Vector2 delta2;

    private float deadZone = 30;

    private bool isSwiping;
    private bool isSwiping2;
    private bool isMobile;

    private bool left_side = true;
    private bool left_side2 = true;

    void Start()
    {
        isMobile = Application.isMobilePlatform;
        isMobile = true;
        Debug.Log("aaaa "+isMobile);
    }

    void Update()
    {
        float p;
        
        if (!isMobile)
        {
            p = Mathf.Abs(Input.mousePosition.x) - Screen.width / 2;
            if (Input.GetMouseButtonDown(0))
            {
                isSwiping = true;
                tapPosition = Input.mousePosition;
                if (p < 0)
                    left_side = true;
                else
                    left_side = false;
            }
            else if(Input.GetMouseButtonDown(0))
                ResetSwipe();
        }
        else
        {
            if (Input.touchCount >= 1) //try 
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    p = Mathf.Abs(Input.GetTouch(0).position.x) - Screen.width / 2;
                    if (p < 0)
                        left_side = true;
                    else
                        left_side = false;

                    isSwiping = true;
                    tapPosition = Input.GetTouch(0).position;
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Canceled || Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    ResetSwipe();
                }
            }
            if (Input.touchCount >= 2)
            {
                Input.multiTouchEnabled = true;
                if (Input.GetTouch(1).phase == TouchPhase.Began)
                {
                    p = Mathf.Abs(Input.GetTouch(1).position.x) - Screen.width / 2;
                    if (p < 0)
                        left_side2 = true;
                    else
                        left_side2 = false;

                    isSwiping2 = true;
                    tapPosition2 = Input.GetTouch(1).position;

                }
                else if (Input.GetTouch(1).phase == TouchPhase.Canceled || Input.GetTouch(1).phase == TouchPhase.Ended)
                {
                    ResetSwipe2();
                }
            }
        }
        CheckSwipe();
    }
    private void CheckSwipe(){
        if(Input.touchCount >= 1 || Input.GetMouseButton(0))
        {
            Debug.Log("there is 1 swipe");
            delta = Vector2.zero;
            if (isSwiping)
            {
                if (!isMobile && Input.GetMouseButton(0))
                {
                    delta = (Vector2)Input.mousePosition - tapPosition;
                }
                else if (Input.touchCount == 1)
                {
                    delta = (Vector2)Input.GetTouch(0).position - tapPosition;
                }
            }
            if (delta.magnitude > deadZone)
            {
                if (SwipeEvent != null)
                {
                    if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
                    {
                        SwipeEvent.Invoke(delta.x > 0 ? Vector2.right : Vector2.left, left_side);
                    }
                    else
                    {
                        SwipeEvent.Invoke(delta.y > 0 ? Vector2.up : Vector2.down, left_side);
                    }
                }
                ResetSwipe();
            }
        }
        else
        {
            Debug.Log("there are NO swipes");
        }
        if (Input.touchCount == 2)
        {
            Debug.Log("there are 2 swipes");
            delta2 = Vector2.zero;
            if (isSwiping2)
            {
                if (Input.touchCount == 2)
                {
                    delta2 = (Vector2)Input.GetTouch(1).position - tapPosition;
                }
            }
            if (delta2.magnitude > deadZone)
            {
                if (SwipeEvent2 != null)
                {
                    if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
                    {
                        SwipeEvent2.Invoke(delta2.x > 0 ? Vector2.right : Vector2.left, left_side2);
                    }
                    else
                    {
                        SwipeEvent2.Invoke(delta2.y > 0 ? Vector2.up : Vector2.down, left_side2);
                    }
                }
                ResetSwipe2();
            }
        }
    }
    private void ResetSwipe()
    {
        isSwiping=false;
        tapPosition=Vector2.zero;
        delta = Vector2.zero;
    }
    private void ResetSwipe2()
    {
        isSwiping2 = false;
        tapPosition2 = Vector2.zero;
        delta2 = Vector2.zero;
    }
}
