using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class fpp_manager : MonoBehaviour
{
	private GameObject Player;
	public Text endString;
	public bool Died=false;
	public Text healthString;
	public int TextDelay;
	public bool Key=false;
	
	public static fpp_manager Instance;
	
	void Awake()
	{
	if (Instance==null)
		{
		Instance=this;	
		} else
			{
			Debug.Log("Multiple manager scripts!");
			return;
			}
	}
	
    void Start()
	{
	Player=GameObject.FindWithTag("Player");
	endString.text="";
	HealthUpdate();
	}

    // Update is called once per frame
    void Update()
    {
    if (Died)
		{
		if (Input.GetButtonDown("Jump"))
			{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);	
			}
		}    
    }
	
	void FixedUpdate()
	{
	if (TextDelay>0)
		{
		TextDelay--;	
		}
	if (TextDelay==0)
		{
		endString.text="";	
		}
	}
	
	public void Death()
	{
	Died=true;
	endString.text="You died! Press 'space' to restart.";
	TextDelay=int.MaxValue;
	Destroy(Player.GetComponent<fpp_character>());
	Destroy(Player.GetComponent<Rigidbody>());
	Destroy(Player.GetComponent<Collider>());
	}
	
	public void HealthUpdate()
	{
	healthString.text=Player.GetComponent<fpp_character>().Health.ToString("F0");	
	}
	
	public void EndUpdate(string Message)
	{
	endString.text=Message;
	TextDelay=150;
	}
	
	public void Win()
	{
	if (Key==true)
		{		
		Died=true;
		endString.text="You Won! Press 'space' to restart.";
		TextDelay=int.MaxValue;
		Destroy(Player.GetComponent<fpp_character>());
		Destroy(Player.GetComponent<Rigidbody>());
		Destroy(Player.GetComponent<Collider>());
		} else
			{
			EndUpdate("Collect the key and then get back here!");	
			}
	}
}
