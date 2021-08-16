using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI texto;

    // Update is called once per frame
    void Update()
    {
        texto.text = "Score: " + GlobalVariables.point;
    }
}
