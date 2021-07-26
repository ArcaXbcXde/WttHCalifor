using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CairBebado : MonoBehaviour {

    public GameObject controlFade;
    
	void Update () {
		if (transform.localRotation.x >= 90 && controlFade.GetComponent<Fade>().fadingIn == false && controlFade.GetComponent<Fade>().fadingOut == false) {
            controlFade.GetComponent<Fade>().comecaFade();
        }
	}
}
