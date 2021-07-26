using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OlharPerto : MonoBehaviour {

    private float dist;

    public float distAtiva;

    public Transform obj, ativa, objDesativado;

    private Animator anima;

    private void Start() {

        anima = GetComponent<Animator>();
    }

    private void Update() {
            
        dist = Vector3.Distance(obj.position, transform.position);

        // Faz aparecer o canvas com os botões se o chat estiver desativado
        if (objDesativado.gameObject.activeSelf == false) {

            ativa.gameObject.SetActive(true);
        } else {
            

            ativa.gameObject.SetActive(false);
        }
    }

    private void OnAnimatorIK(int layerIndex) {

        if (dist < distAtiva) {

            // Cabeça vira para objeto
            anima.SetLookAtWeight(1);
            anima.SetLookAtPosition(obj.position);

            // Faz aparecer o canvas com os botões se o chat estiver desativado
            if (objDesativado.gameObject.activeSelf == false) {

                ativa.gameObject.SetActive(true);
            }
        } else {

            // Cabeça volta para posição normal
            anima.SetLookAtWeight(0);
            ativa.gameObject.SetActive(false);
        }


    }
}
