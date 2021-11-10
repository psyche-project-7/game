using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageSwapper : MonoBehaviour
{
    public GameObject ImageToReplace;
    public GameObject ImageToUse;

    public void OnClick()
    {
        ImageToReplace.GetComponent<UnityEngine.UI.Image>().sprite = ImageToUse.GetComponent<UnityEngine.UI.Image>().sprite;
        Destroy(ImageToUse);
    }
}
