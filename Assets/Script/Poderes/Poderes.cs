using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

interface Poderes 
{
    Sprite powerImage { get; }

    string[] powers { get; }

    string GetBasicAttack();

}
