using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToTargetScript : MonoBehaviour
{   
    
    public GameObject Target;
    [SerializeField] bool _toMouse;
    [SerializeField] float difAngle;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {      
        
        Vector3 Direction =Vector3.zero;
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
                Direction = Target.transform.position - transform.position;
        }
        float Angle = Vector2.SignedAngle(Vector2.right, Direction);
        transform.eulerAngles =new Vector3(0, 0, Angle+difAngle);
    }
}
