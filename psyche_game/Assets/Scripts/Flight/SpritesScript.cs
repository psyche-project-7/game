using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScript : MonoBehaviour
{
    public Sprite[] sprites;

    public Sprite getSprite(string spriteName){
        var sprite = sprites[0];
        for (int i = 0; i < sprites.Length; i++) {
            if (sprites[i].name.Equals(spriteName)){
                sprite = sprites[i];
            }
        }
        return sprite;
    }
}
