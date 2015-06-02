using UnityEngine;
using System.Collections;

public class PowerUpFlower : Collectable {

	public int itemID = 1;

	override protected void OnCollect(GameObject target) {

		var equitedBehavior = target.GetComponent<Equip> ();
		if (equitedBehavior != null) {
			equitedBehavior.currentItem = itemID;
		}
	}
}
