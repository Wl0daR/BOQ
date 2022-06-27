using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpp_character : MonoBehaviour
{
	public float MaxHealth;
	public float Health;
	public float Damage;
	
    // Start is called before the first frame update
    public virtual void Start()
    {
    Health=MaxHealth;
    }

	public void GotHit(float HitDamage)
	{
	Health-=HitDamage;
	if (gameObject.CompareTag("Player"))
		{
		fpp_manager.Instance.HealthUpdate();
		}

	if (Health<=0)
		{
		if (gameObject.CompareTag("Player"))
			{	
			fpp_manager.Instance.Death();
			} else
				{
				Destroy(gameObject);	
				}
		}
	}

}
