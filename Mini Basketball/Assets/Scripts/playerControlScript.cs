using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerControlScript : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject playerCam;
    private Rigidbody bRigidbody;
    [SerializeField] private float distance, forcePower;
    private bool holdingBall=true;
    private float timer;
    [SerializeField] private float newGameTime;


    // Start is called before the first frame update
    void Start()
    {
        bRigidbody=ball.GetComponent<Rigidbody>();
        bRigidbody.useGravity=false;
    }

    void Update () 
    {
        playerAction();
        ResetGame();
    }
    void LateUpdate()
    {
        if(holdingBall) 
        {
            ball.transform.position=playerCam.transform.position+playerCam.transform.forward*distance;
        }
    }

    private void playerAction()
    {
        if(Input.GetMouseButtonDown(0))
        {
            bRigidbody.AddForce(playerCam.transform.forward*forcePower);
            holdingBall=false;
            bRigidbody.useGravity=true;
        }
    }

    private void ResetGame() {
        if(holdingBall==false)
        {
            timer+=Time.deltaTime;
           // Debug.Log(timer);
            if(timer>=newGameTime)
            {
                SceneManager.LoadScene("Game");
            }
        }
    }

    
    
}
