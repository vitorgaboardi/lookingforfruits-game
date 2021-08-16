using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stump : MonoBehaviour
{

    public GameObject finalFruit;

    void Start()
    {
        gameObject.SetActive(true);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "BolaCanhao" || collision.gameObject.tag == "ExplosionFire")
        {
            if(GlobalVariables.phase == 3)
            {
                finalFruit.SetActive(true);
            }
            gameObject.SetActive(false);
        }
    }

}
