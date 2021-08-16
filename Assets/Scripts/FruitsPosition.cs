using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsPosition : MonoBehaviour
{
    List<Vector3> points = new List<Vector3>();     // position points
    GameObject[] objs;                              // fruit objects

    // Start is called before the first frame update
    void Start()
    {
        objs = GameObject.FindGameObjectsWithTag("Fruit");
        
        // Add positions
        if(GlobalVariables.phase != 5)
        {
            points.Add(new Vector3(9.9f, 1.7f, -54.43f));
            points.Add(new Vector3(-12.0f, 0.8f, -45.5f));
            points.Add(new Vector3(43.2f, 0.3f, -42.8f));   
            points.Add(new Vector3(63.0f, 0.3f, -19.0f));
            points.Add(new Vector3(21.3f, 1.7f, -20.0f));   
            points.Add(new Vector3(53.9f, 0.0f, 27.0f));
            points.Add(new Vector3(25.9f, 2.2f, -11.4f));   
            points.Add(new Vector3(16.6f, 0.8f, 45.43f));
            points.Add(new Vector3(-63f, -0.6f, 48.9f));
            points.Add(new Vector3(-54.2f, 0.1f, 28.3f));
        }
        points.Add(new Vector3(-52.3f, -0.9f, -71.7f));
        points.Add(new Vector3(-25.3f, 0.0f, -67.2f));
        points.Add(new Vector3(-52.7f, 0.0f, -81.4f)); 
        points.Add(new Vector3(40f, -0.8f, -86f));
        points.Add(new Vector3(19f, 0.0f, -75f));
        points.Add(new Vector3(-3.12f,-0.8f, -85f));
        points.Add(new Vector3(-32.5f, 0.0f, -84f));

        int index;


        foreach (GameObject obj in objs)
        {
            if(obj.name != "banana")
            {
                index = Random.Range(0,points.Count);
                obj.transform.position = points[index];
                points.RemoveAt(index);
            }
            else
            {
                obj.SetActive(false);
            }
        }
    }

}
