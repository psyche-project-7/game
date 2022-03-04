using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpriteScript : MonoBehaviour
{
    public Sprite[] sprites;

    public Sprite getSprite(string spriteName){
        return Array.Find(sprites, sprite => sprite.name.Equals(spriteName));
    }
}
