using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GeneratorEnemyScript : MonoBehaviour
{
    [SerializeField] BaseEnemy[] Enemys;
    [SerializeField] Transform[] Respawns;
    [SerializeField] Transform player;
    private bool waveflag;
    [SerializeField] float _pause;
    void Start()
    {
        for (int i = 0; i < Enemys.Length; i++)
        {
            Enemys[i].MoveTarget =player; 
        }
        
    }
 void FixedUpdate()
    {
        if (!waveflag)
        {
            StartCoroutine(WaveAttak());
        }
    }

    
    IEnumerator WaveAttak()
    {
        waveflag = true;
        for (int i = 0; i <= 10; i++)
        {
            Instantiate(Enemys[0], Respawns[Random.Range(0, Respawns.Length)].transform.position, transform.rotation);    
            yield return new WaitForSeconds(_pause);    
        }
        if (_pause > 0.1f)
        {
            _pause -= 0.05f;
        }
        
        waveflag = false;
    }
}
