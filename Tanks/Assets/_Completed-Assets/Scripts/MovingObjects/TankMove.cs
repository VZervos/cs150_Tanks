using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMove : MonoBehaviour
{

    [SerializeField] Transform[] Positions;     //the points that we want to move
    public int[] rotate;    //how many degrees has to rotate the moving object when it goes to point
    [SerializeField] float ObjectSpeed; //movement object speed

    int NextPosIndex = 0;
    Transform NextPos;  //the point that the object we want to go

    // Start is called before the first frame update
    void Start()
    {
        NextPos = Positions[0]; //set first move to first object
    }

    // Update is called once per frame
    void Update()
    {
        MoveGameObject();

    }

    //function that moves the object
    void MoveGameObject()
    {
        if (transform.position == NextPos.position)
        {
            //if we hit the next point change rotaion
            if (NextPosIndex >= rotate.Length)
            {
                Vector3 newRotation = new Vector3(0, 0, 0);
                transform.eulerAngles = newRotation;
            }
            else
            {
                Vector3 newRotation = new Vector3(0, rotate[NextPosIndex], 0);
                transform.eulerAngles = newRotation;
            }
            
            //take next point for the object
            NextPosIndex++;
            if (NextPosIndex >= Positions.Length)
            {
                NextPosIndex = 0;
            }
            NextPos = Positions[NextPosIndex];


        }
        else //if we have not hit the point yet keep moving
        {
            
            transform.position = Vector3.MoveTowards(transform.position, NextPos.position, ObjectSpeed * Time.deltaTime);

        }

        
    }

}
