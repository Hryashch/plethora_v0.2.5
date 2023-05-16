using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snake2 : snake
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = Vector2.left;
        }
    }
    private void Restart()
    {
        for (int i = 1; i < body.Count; i++)
        {
            Destroy(body[i].gameObject);
        }
        body.Clear();
        body.Add(this.transform);
        this.transform.position = new Vector3(15, 0, 0.0f);

    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "t" && this.get_l()-2<=othersnake.get_l())
            Grow();
        else if (other.tag == "l")
            Restart();
    }
    
    public override void OnSwipe(Vector2 dir,bool side)
    {
        //Debug.Log(" in OnSwipe() in snake2");
        if (!side)
        {
            //Debug.Log("on swipe shoud be right");
            direction = dir;
        }
    }
    
}
