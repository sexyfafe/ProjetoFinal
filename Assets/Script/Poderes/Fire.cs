using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fire : MonoBehaviour, Poderes
{
    private Spell powerBasic = new Spell("Fireball", 0 , 0);
    private Spell powerMedium = new Spell("Tornado", 20, 20);
    private string _basicAttack_Cast = "Cast";

    public Sprite _powerImage;
    public Sprite powerImage => _powerImage;

    public string basicAttack_Cast => _basicAttack_Cast;

    public Spell[] powers {
        get {
            return new Spell[2] { powerBasic, powerMedium };
        }   
    }

    public string GetBasicAttack()
    {
        return this.powers[0].GetSpellString(); 
    }

    public Spell GetMediumAttack()
    {
        return powers[1];
    }
}
