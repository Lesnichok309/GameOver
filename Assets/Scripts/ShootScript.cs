using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    [SerializeField] GameObject Bullet;
    [SerializeField] float _reloadTime;
    bool _reloadFlag;
   
   
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && !_reloadFlag)
        {
            _reloadFlag = true;
            Instantiate(Bullet,transform.position,transform.rotation);
            Invoke("Reload", _reloadTime);
        }
    }
    
    void Reload()
    {
        _reloadFlag = false;
    }
}
