using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Messages : MonoBehaviour
{

	#region Singleton

	public static Messages instance;

	void Awake ()
	{
		instance = this;
	}

	#endregion

    public TextMeshProUGUI texto;

    IEnumerator Start()
    {
        texto.enabled = false;
        if(GlobalVariables.phase == 1)
        {
            yield return StartCoroutine(this.ShowMessage("Welcome to the Looking for Fruits Game!",3));
            yield return StartCoroutine(this.ShowMessage("You must find all the fruits within the map",3));
            yield return StartCoroutine(this.ShowMessage("When you find a fruit, use left click to get it",3));
            yield return StartCoroutine(this.ShowMessage("Besides, you can eat a fruit and receive a power!",3));
        }
        else if (GlobalVariables.phase == 2)
        {
            yield return StartCoroutine(this.ShowMessage("Looks like you have some enemies",3));
            yield return StartCoroutine(this.ShowMessage("Be careful with the cannon balls from now on",3));
        }
        else if (GlobalVariables.phase == 3)
        {
            yield return StartCoroutine(this.ShowMessage("The enemies are angry",3));
            yield return StartCoroutine(this.ShowMessage("They are firing faster!",3));
            yield return StartCoroutine(this.ShowMessage("Besides, they have hidden a new fruit!",3));
            yield return StartCoroutine(this.ShowMessage("It shall appear when an explosion occurs...",3));
            
        }
        else if (GlobalVariables.phase == 4)
        {
            yield return StartCoroutine(this.ShowMessage("The cannonballs are faster than before!",3));
        }
        else if (GlobalVariables.phase == 5)
        {
            yield return StartCoroutine(this.ShowMessage("Damn! You are good, aren't u?",2.5f));
            yield return StartCoroutine(this.ShowMessage("The enemy has an army now!",2.5f));
            yield return StartCoroutine(this.ShowMessage("Get the fruits and finish the game!",2.5f));
        }
        else if (GlobalVariables.phase == 6)
        {
            yield return StartCoroutine(this.ShowMessage("Congrats! You just finished the game!",3));
            yield return StartCoroutine(this.ShowMessage("Wait for more development!",3));
            yield return StartCoroutine(this.ShowMessage("...",3));
            yield return StartCoroutine(this.ShowMessage("So, what's your grade...",3));
            yield return StartCoroutine(this.ShowMessage("... between 10 and 10?",3));
        }

    }

    public IEnumerator ShowMessage(string message, float delay)
    {
        texto.text = message;
        texto.enabled = true;
        yield return new WaitForSeconds(delay);
        texto.enabled = false;
    }
}
