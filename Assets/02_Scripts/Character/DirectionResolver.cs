using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionResolver : MonoBehaviour
{
    Vector2 direction;
    [SerializeField] private CharDirection[] directions; //0=up, 1=down, 2=left, 3=right
    [HideInInspector] public CharDirection actualDirection;

    private void Start()
    {
        foreach(CharDirection dir in directions)
        {
            if(dir.myDirection == Direction.DOWN)
            {
                dir.gameObject.SetActive(true);
                actualDirection = dir;
            }
            else
            {
                dir.gameObject.SetActive(false);
            }
        }
    }
    public void ChangeDirection(Vector2 dir)
    {
        direction = dir;
        CharDirection newDir = actualDirection;
        if (direction != Vector2.zero)
        {
            float x = dir.x;
            float y = dir.y;
            
            if(x != 0) //SIDE
            {
               
                if(x > 0)
                {
                    //RIGHT
                    newDir = GetDirection(Direction.RIGHT);
                }
                else
                {
                    //LEFT
                    newDir = GetDirection(Direction.LEFT);

                }

            }
            else if(y != 0) //UP OR DOWN
            {
                if (y > 0)
                {
                    //UP

                    if (x > 0)
                    {
                        //UP AND RIGHT
                        newDir = GetDirection(Direction.RIGHT);
                    }
                    else if (x < 0)
                    {
                        //UP AND LEFT
                        newDir = GetDirection(Direction.LEFT);
                    }
                    else
                    {
                        //ONLY UP
                        newDir = GetDirection(Direction.UP);
                    }
                }
                else
                {
                    //DOWN

                    if (x > 0)
                    {
                        //DOWN AND RIGHT
                        newDir = GetDirection(Direction.RIGHT);
                    }
                    else if (x < 0)
                    {
                        //DOWN AND LEFT
                        newDir = GetDirection(Direction.LEFT);
                    }
                    else
                    {
                        //ONLY DOWN
                        newDir = GetDirection(Direction.DOWN);
                    }
                }
            }
        }
        else
        {
            if(actualDirection)
            {

            }
            //STOP
        }



        if(actualDirection)
        {
            actualDirection.gameObject.SetActive(false);
        }

        actualDirection = newDir;
        actualDirection.gameObject.SetActive(true);
        actualDirection.InvertAnimation(actualDirection.myDirection == Direction.LEFT);
    }

    CharDirection GetDirection(Direction dir)
    {
        foreach(CharDirection dires in directions)
        {
            if(dires.myDirection == dir)
            {
                return dires;
            }
        }

        return directions[1];

    }


}
