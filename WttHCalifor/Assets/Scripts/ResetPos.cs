using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPos : MonoBehaviour {

    private Vector3 posInicial;
    
	void Start () {
        posInicial = transform.position;
	}
	
	void Update () {
        // se cair do chão volta à posição onde começou ao abrir o jogo
		if (transform.position.y < -2) {
            ResetPosicao();
        }
	}

    public void ResetPosicao() {
        transform.position = posInicial;
    }
}
