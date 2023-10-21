using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transfer : MonoBehaviour
{    

    float coolDown = 3f;
    float lastTimeTransfer;
    public GameObject[] Players;
    int playerno;
    void Start()
    {
        lastTimeTransfer = Time.time;
        playerno = 0;
    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E)  && Time.time - lastTimeTransfer > coolDown && playerno==0)
        {
            transform.position = new Vector2(Players[0].transform.position.x, 25.0f);
            Players[playerno].SetActive(false);
            playerno++;
            Players[playerno].SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.E)  && Time.time - lastTimeTransfer > coolDown && playerno == 1)
        {
            transform.position = new Vector2(Players[1].transform.position.x, 1.0f);
            Players[playerno].SetActive(false);
            playerno--;
            Players[playerno].SetActive(true);
        }
    }
    

}
