using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaFunc : MonoBehaviour {

    public float distAparece = 5;

    public Transform canvas1, canvas2, outro;

    private float dist;

    private Quaternion initRotacao;

    private bool aberto = false;

    private AudioSource som;

    void Start () {

        som = GetComponent<AudioSource>();

        initRotacao = transform.rotation;
	}


    void Update () {
        dist = Vector3.Distance(outro.position, transform.position);
        // se o jogador estiver perto...
        if (dist < distAparece) {

            // e a porta estiver fechada, mostra os canvas com as opções da porta...
            if (aberto == false) {

                canvas1.gameObject.SetActive(true);
                canvas2.gameObject.SetActive(true);

            // e se estiver aberta os canvas ficam invisíveis
            } else {

                canvas1.gameObject.SetActive(false);
                canvas2.gameObject.SetActive(false);
            }

            // se apertar a tecla E...
            if (Input.GetKeyDown(KeyCode.E)) {

                if (aberto == false) {
                    // toca som da porta se ela estava fechada (ainda não mudou a variável)...
                    som.enabled = true;
                    som.time = 2f;
                }
                // e gira a porta
                transform.rotation = new Quaternion(0, 0, 0, 0);
                aberto = true;

            }
        
        // se o jogador estiver longe da porta...
        } else {

            // e estiver aberta, faz o som dela fechando...
            if (aberto == true) {
                som.enabled = true;
                som.time = 15.8f;
            }

            // e fecha deixando os canvas invisíveis também
            canvas1.gameObject.SetActive(false);
            canvas2.gameObject.SetActive(false);
            transform.rotation = initRotacao;
            aberto = false;
        }

        // se o som durou muito tempo apenas para
        if ((som.time >= 2.7f && som.time < 15.8) || som.time >= 16.4f) {

            som.enabled = false;
        }
    }
}
