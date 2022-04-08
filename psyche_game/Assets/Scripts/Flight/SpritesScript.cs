using System.Collections;
using UnityEngine;
using System;

public class SpritesScript : MonoBehaviour
{
    public static Sprite[] sprites;
    public Sprite[] useSprites;

    public static Sprite getSprite(string spriteName){
        return Array.Find(sprites, sprite => sprite.name.Equals(spriteName));
    }

    private void Awake() {
        sprites = useSprites;
    }
}
