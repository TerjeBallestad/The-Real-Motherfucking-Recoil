using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.CorgiEngine;



public class CharacterRecoil: CharacterAbility
{
    public void AddRecoil(Vector2 recoil)
    {
        _controller.SetForce(new Vector2(recoil.x, recoil.y));

    }
}
