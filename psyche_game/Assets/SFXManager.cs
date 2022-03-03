using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
   public AudioSource Audio;

   public AudioClip Click;

   public static SFXManager sfxInstance;

   private void Awake()
   {
       if (sfxInstance != null && sfxInstance != this)
       {
           Destroy(this.gameObject);
           return;
       }

       sfxInstance = this.;
       DontDestroyOnLoad(this)
   }
        
    }
}
/* 
I need to make sure that this instance is being used correctly. I will have to look at this more next sprint.