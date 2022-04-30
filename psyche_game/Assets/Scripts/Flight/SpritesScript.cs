using System.Collections;
using UnityEngine;
using System;

public class SpritesScript : MonoBehaviour
{
    public static Sprite[] sprites;
    public Sprite[] useSprites;

    public static Sprite getSprite(string spriteName){
        Debug.Log(Array.Find(sprites, sprite => sprite.name.Equals(spriteName)));
        return Array.Find(sprites, sprite => sprite.name.Equals(spriteName));
    }

    private void Awake() {
        sprites = useSprites;
    }
}
