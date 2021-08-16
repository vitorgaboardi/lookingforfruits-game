using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    public Rigidbody projectile;
    //public GameObject rockPrefab;
    GameObject player;
    public float speed = 40;

    void Start()
    {
        player = GameObject.Find("FirstPersonPlayer");

        if(GlobalVariables.phase == 2)
        {
            InvokeRepeating("cannonBall", 5.0f, 4.0f);
        }
        else if(GlobalVariables.phase == 3)
        {
            InvokeRepeating("cannonBall", 3.0f, 2.0f);
        }
        else if(GlobalVariables.phase == 4)
        {
            InvokeRepeating("cannonBall", 2.0f, 1.0f);
        }
        else if(GlobalVariables.phase == 5)
        {
            InvokeRepeating("cannonBall", 2.0f, 0.5f);
        }
    }

    private void cannonBall()
    {
        // Origem Info
        float xVar1 = Random.Range(-90f,76f);
        transform.position = new Vector3(xVar1, transform.position.y, transform.position.z);
        Rigidbody p = Instantiate(projectile, transform.position, transform.rotation);

        // Projectile Info
        float xVar2 = Random.Range(-5f,5f);
        Vector3 destination = new Vector3(player.transform.position.x+xVar2, player.transform.position.y, player.transform.position.z);
        Vector3 velocity = BallisticVelocity(destination, 20f);
        p.velocity = velocity;
    }

    private Vector3 BallisticVelocity(Vector3 destination, float angle)
    {
        Vector3 dir = destination - transform.position;
        float height = dir.y;
        dir.y = 0;
        float dist = dir.magnitude;
        float a = angle * Mathf.Deg2Rad;
        dir.y = dist * Mathf.Tan(a);
        dist += height / Mathf.Tan(a);

        // Compute the velocity magnitude
        float velocity = Mathf.Sqrt(dist * Physics.gravity.magnitude / Mathf.Sin(2 * a));
        return velocity * dir.normalized;
    }
}
