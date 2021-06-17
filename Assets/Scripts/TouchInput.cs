using UnityEngine;
using System.Collections;

public class TouchInput : MonoBehaviour
{
    public Vector2 startPosition = new Vector2(0,0);
    public Vector2 endPosition = new Vector2(0,0);
    //direction's drag
    private bool upward = false;
    private bool downward = false;
    private bool toTheRight = false;
    private bool toTheLeft = false;
    //input lag time in frames
    private int inputLagTime = 3;
    //minimum size to be considered a drag
    private float minimunSizeDistance = Screen.width/6;
    public bool GetUpward(){
        return upward;
    }
    public bool GetDownward(){
        return downward;
    }
    public bool GetToTheRight(){
        return toTheRight;
    }
    public bool GetToTheLeft(){
        return toTheLeft;
    }
    public Vector2 GetDirection(){
        if(GetUpward()){
            return Vector2.up; 
        }else if(GetDownward()){
            return Vector2.down; 
        }else if(GetToTheRight()){
            return Vector2.right; 
        }else if(GetToTheLeft()){
            return Vector2.left; 
        }else{
            return new Vector2(0,0);
        }
    }

    void Update()
    {
        // Track a single touch as a direction control.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            // Handle finger movements based on TouchPhase
            switch (touch.phase)
            {
                //When a touch has first been detected, change the message and record the starting position
                case TouchPhase.Began:
                    // Record initial touch position.
                    startPosition = touch.position;
                    break;
                //Determine if the touch is a moving touch
                case TouchPhase.Moved:
                    // Determine direction by comparing the current touch position with the initial one
                    //TODO: Make a function to direction of drag
                    break;
                case TouchPhase.Ended:
                    // Report that the touch has ended when it ends
                    endPosition = touch.position;
                    DragDirectionInput();
                    break;
            }
        }
    }
    private void ResetInputValues(){
        upward = false;
        downward = false;
        toTheRight = false;
        toTheLeft = false;
    }
    public void DragDirectionInput(){
        float x = endPosition.x - startPosition.x;
        float y = endPosition.y - startPosition.y;
        float sizeOfDrag = Mathf.Sqrt(Mathf.Pow((endPosition.x - startPosition.x),2)+Mathf.Pow((endPosition.y - startPosition.y),2));
        if(sizeOfDrag >= minimunSizeDistance){
            if (Mathf.Abs (x) > Mathf.Abs (y)) {
                if(endPosition.x < startPosition.x){
                    toTheLeft = true;
                }else if(endPosition.x > startPosition.x){
                    toTheRight = true;
                }
            }else{
                if(endPosition.y < startPosition.y){
                    downward = true;
                }else if(endPosition.y > startPosition.y){
                    upward = true;
                }
            }
            Invoke("ResetInputValues",Time.deltaTime * inputLagTime);
        }
        
    }
}