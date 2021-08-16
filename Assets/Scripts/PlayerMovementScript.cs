using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using UnityEngine.SceneManagement;      // Restart the scene!

public static class GlobalVariables{
    public static int phase = 1; 
    public static int point = 0;
    public static int currentHp = 100;
 }

public class PlayerMovementScript : MonoBehaviour
{
    
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 5f;

    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public Transform groundCheck;

    Vector3 velocity;
    bool isGrounded;
    bool isFruitNearby;
    float distanceToFruit = 4.0f;

    public HealthBar healthBar;
    float timeColliding;
    float timeThreshold = 0.1f;                // at each second in the fire, it will lose hp.

    public Messages texto;

    GameObject[] objs;                              // fruit objects
    GameObject fruit;
    int fruitsEaten = 0;

    void Start()
    {
        healthBar.SetMaxHealth(GlobalVariables.currentHp);
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Getting axis information to move the player through the scene
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // Jump
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Add gravity into the game
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Check if player is nearby a fruit
        fruitNearby();
        if(checkFruitExistence() == false)
        {
            StartCoroutine(texto.ShowMessage("Nice! You just finished level " + GlobalVariables.phase + "!", 2));
            StartCoroutine(NextLevel());
        }

        // Checking if player still alive
        if(GlobalVariables.currentHp <= 0)
        {
            StartCoroutine(texto.ShowMessage("Game Over.", 3));
            StartCoroutine(ResetGame());
        }
    }

    IEnumerator ResetGame()
    {
        yield return new WaitForSeconds(2);
        GlobalVariables.currentHp = 100;
        GlobalVariables.phase = 1;
        GlobalVariables.point = 0;
        SceneManager.LoadScene("Config",LoadSceneMode.Single);    // Always Load everything related to Config Scene
        SceneManager.LoadScene("Fase1", LoadSceneMode.Additive);
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(2);

        GlobalVariables.phase+=1;
        SceneManager.LoadScene("Config",LoadSceneMode.Single);    // Always Load everything related to Config Scene
        SceneManager.LoadScene("Fase1", LoadSceneMode.Additive);
    }

    void fruitNearby()
    {
        objs = GameObject.FindGameObjectsWithTag("Fruit");

        // Check if the player is near the fruit
        foreach (GameObject obj in objs)
        {
            isFruitNearby = Vector3.Distance(transform.position, obj.transform.position) <= distanceToFruit;
            if(isFruitNearby)
            {
                fruit = obj;
                break;
            }
        }
         
        // Get the fruit 
        if(Input.GetButtonDown("Fire1") && isFruitNearby)
        {
            // Display message!
            StartCoroutine(texto.ShowMessage("Nice! You just got the " + fruit.name, 3));
            fruitsEaten+=1;
            if(fruit.name != "banana")
            {
                GlobalVariables.point+=100*GlobalVariables.phase;
            }
            else
            {
                GlobalVariables.point+=800;
            }
            Destroy(fruit);
        }
    }

    bool checkFruitExistence()
    {
        if(GlobalVariables.phase != 3)
        {
            objs = GameObject.FindGameObjectsWithTag("Fruit");
            if(objs.Length == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            if(fruitsEaten == 5)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }

    }

    // If player collided with CannonBall
    void OnCollisionEnter(Collision collision)
    {
        timeColliding = 0f;
        if(collision.gameObject.tag == "BolaCanhao")
        {
            GlobalVariables.currentHp-=25;
            healthBar.SetHealth(GlobalVariables.currentHp);
        }
    }

    // If player stayed on fire
    void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "ExplosionFire") {
            if (timeColliding < timeThreshold) {
                 timeColliding += Time.deltaTime;
             } else {
                 GlobalVariables.currentHp-=3;
                 timeColliding = 0f;
                 healthBar.SetHealth(GlobalVariables.currentHp);
             }
         }   
    }
}
