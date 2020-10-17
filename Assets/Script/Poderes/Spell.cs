using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    private string spellString;
    private int spellRotation;
    private int spellPosition;

    public Spell(string spell, int rotation, int position)
    {
        spellString = spell;
        spellRotation = rotation;
        spellPosition = position;
    }

    public string GetSpellString()
    {
        return spellString;
    }

    public int GetSpellRotation()
    {
        return spellRotation;
    }

    public int GetSpellPosition()
    {
        return spellPosition;
    }
}
