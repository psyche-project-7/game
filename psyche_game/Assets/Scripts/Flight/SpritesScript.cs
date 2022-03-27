using System.Collections;
using UnityEngine;
using System;

public class SpritesScript : MonoBehaviour
{
    public static Sprite[] sprites;

    public static Sprite getSprite(string spriteName){
        return Array.Find(sprites, sprite => sprite.name.Equals(spriteName));
    }
}
