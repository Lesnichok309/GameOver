using System.Collections;
using UnityEditor.Timeline.Actions;
using UnityEngine;
public interface IShootStrategy
{
    public GameObject Bullet {get;set;} 
    public float ShootDelay {get;set;}
    public int Clip{get;set;}
    public float ReloadTime {get;set;}
    public int Damage{get;set;}
    public bool CanShoot{get;set;}
    public void Shoot();
    public IEnumerator ShootAndReload();

    public void NewInit(GameObject newBullet,float newShootDelay,int newClip,float newReloadTime,int newDamage)
    {
        Bullet = newBullet;
        ShootDelay = newShootDelay;
        Clip = newClip;
        ReloadTime = newReloadTime;
        Damage = newDamage;
    }
}
