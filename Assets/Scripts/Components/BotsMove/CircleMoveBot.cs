using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMoveBot : BaseMoveBot
{
    private Vector3 direction;
    void Start()
    {
        if(Random.Range(0,2) == 0)
        {
            direction = Vector3.forward;    
        }
        else
        {
            direction = Vector3.back;
        }
        
    }
    public override void Move()
    {   
        float distanse = Vector2.Distance(transform.position,moveTarget.position);
        if(distanse > 4)
        {
            transform.Translate(Vector2.right * Time.deltaTime * Speed);    
        }
        else
        {
            transform.RotateAround(moveTarget.position,direction,speed*Time.deltaTime*10);
        }
        
    }    
}
