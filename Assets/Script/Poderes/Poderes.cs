using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

interface Poderes 
{
    Sprite powerImage { get; }

    Spell[] powers { get; }
    string basicAttack_Cast { get; }

    string GetBasicAttack();

    Spell GetMediumAttack();

}
