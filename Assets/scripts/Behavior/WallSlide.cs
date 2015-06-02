using UnityEngine;
using System.Collections;

public class WallSlide : StickToWall {

	public float slideVelocity = -5;
	public float slideMultiplayer = 5f;
	public GameObject dustPrefab;
	public float dustSpawnDelay = 0.5f;

	private float timeEnlapsed = 0f;

	// Update is called once per frame
	override protected void Update () {
		base.Update ();

		if (onWallDetected && !collisionState.standing) {
			var velY = slideVelocity;

			if(inputState.GetButtonValue(inputButtons[0]))
				velY *= slideMultiplayer;

			body2d.velocity = new Vector2(body2d.velocity.x, velY);

			if( timeEnlapsed > dustSpawnDelay) {
				var dust = Instantiate(dustPrefab);
				var pos = transform.position;
				pos.y += 2;
				dust.transform.position = pos;
				dust.transform.localScale = transform.localScale;
				timeEnlapsed = 0f;
			}

			timeEnlapsed += Time.deltaTime;
		}
	}

	override protected void OnStick() {
		body2d.velocity = Vector2.zero;
	}

	override protected void OffWall() {
		timeEnlapsed = 0f; 
	}
}
