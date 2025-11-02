using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    public int lives;

    void FixedUpdate()
    {
        transform.Translate(Vector2.right * Time.deltaTime * _speed * Input.GetAxis("Horizontal"),Space.World);
        transform.Translate(Vector2.up * Time.deltaTime * _speed * Input.GetAxis("Vertical"),Space.World);
    }
   
}
