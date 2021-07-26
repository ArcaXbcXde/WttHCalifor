using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExemploUso : MonoBehaviour {

    public void Funcao() {

        Debug.Log("Funciona");
    }

    private void OnTriggerStay(Collider colTest) {

        if (colTest.tag == "Player" && Input.GetKeyDown(KeyCode.E)) {

            Funcao();
        }
    }
}
