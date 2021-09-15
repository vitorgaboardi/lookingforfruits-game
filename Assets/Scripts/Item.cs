using UnityEngine;
using System;

/* The base item class. All items should derive from this. */

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {

	new public string name = "New Item";	// Name of the item
	public Sprite icon = null;				// Item icon
	public bool showInInventory = true;

	// Called when the item is pressed in the inventory
	public virtual void Use ()
	{
		
		// Something may happen
		if(name == "Apple")
		{
			// If it eats an apple, it gains 30 HP
			int newLife = GlobalVariables.currentHp + 30;
			GlobalVariables.currentHp = Math.Min(100, newLife);
			HealthBar.instance.SetHealth(GlobalVariables.currentHp);
			Debug.Log("You gained 30 hp!");
		}
		else if(name == "Peach")
		{
			float newSpeed = PlayerMovementScript.instance.speed*2;
			PlayerMovementScript.instance.speed = newSpeed;
			Debug.Log("Your speed doubled!");
		}
		else if(name == "Lemon")
		{
			float newJump = PlayerMovementScript.instance.jumpHeight*2;
			PlayerMovementScript.instance.jumpHeight = newJump;
			Debug.Log("You can jump higher!");
		}
		else if(name == "Strawberry")
		{
			int newdamageCannon = PlayerMovementScript.instance.damageCannon/2;
			PlayerMovementScript.instance.damageCannon = newdamageCannon;

			int newdamageFire = PlayerMovementScript.instance.damageFire/2;
			PlayerMovementScript.instance.damageFire = newdamageFire;

			Debug.Log("You are tougher!");
		}
	}

	// Call this method to remove the item from inventory
	public void RemoveFromInventory ()
	{
		Inventory.instance.Remove(this);
	}

}