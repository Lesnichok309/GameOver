using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GeneratorEnemyScript : MonoBehaviour
{
    [SerializeField] BaseEnemy[] Enemys;
    [SerializeField] Transform[] Respawns;
    [SerializeField] Transform player;
    private bool waveflag;
    [SerializeField] float _pause;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Enemys.Length; i++)
        {
            Enemys[i].SetTarget(player); 
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
        Instantiate(Enemys[0], Respawns[Random.Range(0, 4)].transform.position, transform.rotation);
        Instantiate(Enemys[0], Respawns[Random.Range(0, 4)].transform.position, transform.rotation);
        Instantiate(Enemys[0], Respawns[Random.Range(0, 4)].transform.position, transform.rotation);
        Instantiate(Enemys[0], Respawns[Random.Range(0, 4)].transform.position, transform.rotation);
        yield return new WaitForSeconds(_pause);
        if (_pause > 0.1f)
        {
            _pause -= 0.05f;
        }
        else
        {
            _pause = 0.1f;
        }
        waveflag = false;
    }
}
