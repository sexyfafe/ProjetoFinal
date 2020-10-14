using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fire : MonoBehaviour, Poderes
{
    private string powerBasic = "Fireball";
    private string powerMedium;

    public Sprite _powerImage;
    public Sprite powerImage => _powerImage;

    public string[] powers {
        get {
            return new string[2] { powerBasic, powerMedium };
        }   
    }

    public string GetBasicAttack()
    {
        return this.powers[0]; 
    }
}
