using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    [SerializeField] GameObject Cristall;
    [SerializeField] float _reloadTime;
    bool _reloadFlag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0)&& !_reloadFlag)
        {
            //Time.timeScale = 0;
            _reloadFlag = true;
            Instantiate(Cristall,transform.position,transform.rotation);
            Invoke("Reload", _reloadTime);
        }
    }
    void Reload()
    {
        _reloadFlag = false;
    }
}
