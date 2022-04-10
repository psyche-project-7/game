using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicScript : MonoBehaviour
{
    public static BackgroundMusicScript BackgroundMusicInstance;

    private void Awake()

    {

        if(BackgroundMusicInstance != null && BackgroundMusicInstance != this)
        
        { 
            Destroy(this.gameObject);
            return;
        }
        
         
        BackgroundMusicInstance = this;
        DontDestroyOnLoad(this);
    }
}
