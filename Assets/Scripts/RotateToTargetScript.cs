using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToTargetScript : MonoBehaviour
{   
    
    public GameObject Target;
    [SerializeField] bool _toMouse;
    [SerializeField] float difAngle;
    
    void FixedUpdate()
    {      
        Vector3 Direction = Vector3.zero;
        if (_toMouse)
        {
            Vector3 MousePos = Input.mousePosition;
            MousePos = Camera.main.ScreenToWorldPoint(MousePos);
            MousePos = new Vector3(MousePos.x, MousePos.y, 0);
            Direction = MousePos - transform.position;
        }
        else
        {
            if (Target != null)
            {
                Direction = Target.transform.position - transform.position;
            }
            else
            {
                Debug.LogError("Lose target", transform);
                this.enabled = false;
            }
        }
        float Angle = Vector2.SignedAngle(Vector2.right, Direction);
        transform.eulerAngles =new Vector3(0, 0, Angle+difAngle);
    }
}
