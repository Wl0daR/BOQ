using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fpp_weapon : MonoBehaviour
{
	
	public Transform Target;
	public Transform Target2;
	public Vector3 Offset;
	public GameObject ammo;
	public GameObject Player;


    // Update is called once per frame
    void Update()
    {
    Quaternion rotacja=Quaternion.Euler(Target2.eulerAngles.x,Target.eulerAngles.y,0);
	transform.position=Target2.position+(rotacja*Offset);
	
	transform.rotation=Target2.rotation*Quaternion.Euler(90,0,0);

		if (Input.GetButtonDown("Fire1"))
		{
			if (Player.GetComponent<fpp_mechanics>().nAmmo > 0)
			{
				var tempAmmo = Instantiate(ammo, transform.position, transform.rotation);
				tempAmmo.GetComponent<fpp_ammo>().Damage = Target.gameObject.GetComponent<fpp_character>().Damage;
				Player.GetComponent<fpp_mechanics>().nAmmo--;
				Player.GetComponent<fpp_mechanics>().AmmoUpdate();
			}
			if (Player.GetComponent<fpp_mechanics>().nAmmo == 0)
			{
				Player.GetComponent<fpp_mechanics>().OutOfAmmo();
			}
			else { Player.GetComponent<fpp_mechanics>().Update(); }
		}
    }
}
