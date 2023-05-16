using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snake : MonoBehaviour
{
    protected Vector2 direction = Vector2.right;
    protected List<Transform> body;

    public Transform segment;
    [SerializeField] protected snake othersnake;
    //Swipe sw;
    public int get_l()
    {
        return body.Count-1;
    }
    void Awake()
    {
        Swipe.SwipeEvent += OnSwipe;
        Swipe.SwipeEvent2 += OnSwipe;
        body = new List<Transform>();
        body.Add(this.transform);
    }

    public virtual void OnSwipe(Vector2 dir,bool side)
    {
        //Debug.Log(" in OnSwipe() in snake111111111111");
        
            //Debug.Log("on swipe shoud be left");
        if(side)
            direction = dir;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W)){
            direction = Vector2.up;
        }else if (Input.GetKeyDown(KeyCode.S)){
            direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.D)){
            direction = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.A)){
            direction = Vector2.left;
        }
    }
    private void FixedUpdate()
    {
        if (body != null)
        {
            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i].position = body[i - 1].position;
            }
        }
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + direction.x,
            Mathf.Round(this.transform.position.y) + direction.y,
            0.0f
        );

    }
    private void Restart()
    {
        for(int i = 1; i < body.Count; i++)
        {
            Destroy(body[i].gameObject);
        }
        body.Clear();
        body.Add(this.transform);

        this.transform.position = new Vector3(-15, 0, 0.0f);
    }
    protected void Grow()
    {
        Transform segment = Instantiate(this.segment);
        segment.position = body[body.Count - 1].position;

        body.Add(segment);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "t" && this.get_l() - 2 <= othersnake.get_l())
            Grow();
        else if (other.tag == "l")
            Restart();
    }
    public void Button(string d)
    {
        if (d=="up")
        {
            direction = Vector2.up;
        }
        else if (d=="down")
        {
            direction = Vector2.down;
        }
        else if (d=="right")
        {
            direction = Vector2.right;
        }
        else if (d=="left")
        {
            direction = Vector2.left;
        }
    }

}
