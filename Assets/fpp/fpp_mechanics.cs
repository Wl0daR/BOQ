using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fpp_mechanics : MonoBehaviour
{

    public float nAmmo = 0;
    public Text ammoString;
    public Text outammoString;
    public Text EasterEggString;
    private int EasterEgg = 0;

    // Start is called before the first frame update
    public void Start()
    {
        ammoString.text = "Ammo: " + nAmmo.ToString();
        EasterEggString.text = "Easter Egg: " + EasterEgg + "/1";
        outammoString.text = " ";
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("EasterEgg"))
        {
            EasterEgg++;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("ammoBag"))
        {
            nAmmo = nAmmo + 5;
            AmmoUpdate();
            Destroy(collision.gameObject);
        }
    }
    public void AmmoUpdate()
    {
        ammoString.text = "Ammo: " + nAmmo.ToString();
    }
    public void OutOfAmmo()
    {
        if (nAmmo == 0)
        {
            outammoString.text = "You are out of ammo!";
        }
    }
    public void Update()
    {
        EasterEggString.text = "Easter Egg: " + EasterEgg + "/1";
        if (nAmmo > 0)
        {
            outammoString.text = " ";
        }
    }
}
