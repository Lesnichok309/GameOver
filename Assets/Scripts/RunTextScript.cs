using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RunTextScript : MonoBehaviour
{
    public TextMeshProUGUI RunText;

    public string myText;

    string newText = "";

    private Vector3 StartPos;
    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position;
        //StartCoroutine(RunTextRun());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.left*Time.deltaTime*10);
        if (transform.position.x < -20)
        { 
            transform.position = StartPos;
        }
    }

    IEnumerator RunTextRun()
    {
        myText = RunText.text + "   " + myText + "   ";
        RunText.text = "";
        newText = "";
        for (int i = 0; i < myText.Length; i++)
        {
            newText += myText[i];
            RunText.text = newText;  
            yield return new WaitForSeconds(0.2f);
        }
        yield return null;
        StopAllCoroutines();
        StartCoroutine(RunTextRun());
    }

}
