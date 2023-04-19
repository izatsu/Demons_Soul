using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGuide : MonoBehaviour
{
    public void Ok()
    {
        AudioManager.Instance.PlaySFX("ButtonBack");
        Destroy(gameObject);
    }    
}
