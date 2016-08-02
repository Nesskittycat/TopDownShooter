using UnityEngine;
using System.Collections;



[RequireComponent (typeof (AudioSource))]
public class Gun : MonoBehaviour {

	public enum GunType {Semi, Burst,Auto};
	public GunType gunType;
	public float rpm;


	//where the bullet is coming from
	public Transform spawn;


	//System
	private float secondsBetweenShots;
	private float nextPossibleShootTime;

	void Start() {
		secondsBetweenShots = 60 / rpm;
	}
	public void Shoot() {

		if (CanShoot ()) {

			Ray ray = new Ray (spawn.position, spawn.forward);
			RaycastHit hit;
			float shotDistance = 20;
			if (Physics.Raycast (ray, out hit, shotDistance)) {
				//object it hits
				shotDistance = hit.distance;
			}
			//Debug.DrawRay (ray.origin, ray.direction * shotDistance, Color.red, 1);

			nextPossibleShootTime = Time.time + secondsBetweenShots;
		}
		GetComponent<AudioSource>().Play ();
	}

	public void ShootContinuous() {
		if (gunType == GunType.Auto) {
			Shoot ();
		}
	}

	private bool CanShoot() {
		bool canShoot = true;
		if (Time.time < nextPossibleShootTime) {
			canShoot = false;
		}
		return canShoot;
	}
}
