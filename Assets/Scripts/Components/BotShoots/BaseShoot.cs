using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseShoot : MonoBehaviour, IShootStrategy
{
    [SerializeField] protected GameObject bullet;
    public GameObject Bullet {get{return bullet;} set{bullet = value;}} 

    [SerializeField] protected float shootDelay = 0.5f;
    public float ShootDelay { get{return shootDelay;} set{if(value > 0) shootDelay = value;}}
    
    [SerializeField] protected int clip = 1;
    public int Clip{ get{return clip;} set{if(value>=1) clip = value;}}

    protected int localClip;

    [SerializeField] protected float reloadTime = 0;
    public float ReloadTime {get{return reloadTime;} set{if(value>=0)reloadTime = value;}}

    [SerializeField] protected int damage = 1;
    public int Damage{get{return damage;} set{ if(value>0) damage = value;}}

    [SerializeField]protected bool canShoot = true;
    public bool CanShoot{get{return canShoot;}set{canShoot = value;}}

    void Start()
    {
        localClip = Clip;
    }

    void FixedUpdate()
    {
        Shoot();
    }

    public virtual void Shoot()
    {
        if(CanShoot)
        {
            StartCoroutine(ShootAndReload());
        }
    }
    public virtual IEnumerator ShootAndReload()
    {
        CanShoot = false;
        if(localClip > 0)
        {
            GameObject newBullet = Instantiate(bullet,transform.position,transform.rotation);    
            newBullet.tag = tag;
            localClip--;
             yield return new WaitForSeconds(shootDelay);
            if(localClip == 0)
            {
                yield return new WaitForSeconds(reloadTime);
                localClip = clip;
            }
            CanShoot = true;
        }
        else
        {
            Debug.LogError("Start clip weapon is 0");
        }
    }
}
