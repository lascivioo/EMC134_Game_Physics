using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_Blink : MonoBehaviour
{
    Text text;

    public GameObject spaceShip;
    bool blinkReady;
    public bool blinkStart;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        spaceShip = GameObject.FindGameObjectWithTag("Spaceship");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(spaceShip.GetComponent<PhysicsEngine>().NetForceTrue);
        if (!blinkReady)
        {
            Text_Blinking();
            blinkReady = true;
        }
    }

    void Text_Blinking(){
        blinkStart = spaceShip.GetComponent<PhysicsEngine>().NetForceTrue;
        if (blinkStart)
        {
            StartCoroutine(BlinkUnbalanced());
            blinkStart = false;
        }
        else
        {
            StartCoroutine(BlinkBalanced());
        }
    }

    IEnumerator BlinkUnbalanced()
    {
        while(true)
        {
            text.text = "";
            yield return new WaitForSeconds(1f);
            text = GetComponent<Text>();
            text.color = Color.red;
            text.fontSize = 30;
            text.text = "Unbalanced Force Detected";
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator BlinkBalanced()
    {
        while(true)
        {
            text.text = "";
            yield return new WaitForSeconds(1f);
            text = GetComponent<Text>();
            text.color = Color.green;
            text.fontSize = 30;
            text.text = "SUCCESS";
            yield return new WaitForSeconds(1f);
        }
    }
}