using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    [SerializeField] GameObject Bullet;
    [SerializeField] float reloadTime;
    [SerializeField] int damage;
    bool _reloadFlag;

    void Start()
    {
        Bullet.GetComponent<CristallScript>().SetDamage(damage);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && !_reloadFlag)
        {
            _reloadFlag = true;
            GameObject newBullet = Instantiate(Bullet,transform.position,transform.rotation);    
            newBullet.tag = tag;
            Invoke("Reload", reloadTime);
        }
    }
    
    void Reload()
    {
        _reloadFlag = false;
    }
}
