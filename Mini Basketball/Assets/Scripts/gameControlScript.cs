using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameControlScript : MonoBehaviour
{
    AudioSource soundeffect;
    GameObject effect;
    void Start()
    {
        soundeffect=GetComponent<AudioSource>();
        effect=GameObject.FindGameObjectWithTag("effectTag");
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag=="ballTag")
        {
            GetComponent<BoxCollider>().enabled=false;
            soundeffect.Play();
            effect.GetComponent<effectControlScript>().activeEff();
        }
    }
}
