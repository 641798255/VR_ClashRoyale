using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimtorCtrl : MonoBehaviour {
    
    void OnEnable()
    {
        this.GetComponent<Animator>().SetTrigger("Walk");
    }
}
