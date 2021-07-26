using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogoInicial : MonoBehaviour {

    /*
     * INT
     * fluxo: ponto atual da conversa
     * 
     * FLOAT
     * cdLinha: recarga para falar a próxima linha do diálogo
     * 
     * BOOL
     * acabou: sinalização para verificar se a conversa já acabou
     * 
     * OBJETOS
     * conversa: objeto DIALOGO para armazenar todas as falas do personagem do gatilho
     * 
     * quadroFala: objeto GAMEOBJECT para mostrar onde os textos irão aparecer
     * 
     * controleDialogo: objeto DIALOGOCONTROL feito para armazenar onde está o script que controla o diálogo ao invés de sempre procurar
     * 
     */

    private int fluxo = 0;

    private float cdLinha = 0.1f;

    private bool acabou = false;

    public Dialogo conversa;

    public GameObject quadroFala;

    private DialogoControl controleDialogo;

    private void Awake() {

        controleDialogo = FindObjectOfType<DialogoControl>();
    }

    private void Update() {

        // controle para andar com as linhas da conversa
        if (cdLinha > 0.0f) {

            cdLinha -= Time.deltaTime;
        
        // ativar conversa das linhas de 1 a 4 da recepcionista  
        } else if (cdLinha <= 0 && fluxo > 0 && fluxo < conversa.linhas.Length) { // ! para continuar o diálogo com a recepcionista basta colocar outro else if com fluxo > 4 && fluxo < n

            controleDialogo.MostrarProximaLinha();
            fluxo += 1;
            cdLinha = 1.75f;
        } else if (cdLinha <= 0 && (fluxo == conversa.linhas.Length && acabou == false)) { // ! adicionar cada linha que a recepcionista para de conversar com o jogador

            acabou = true;
            quadroFala.gameObject.SetActive(false);
        }
    }

    // Gatilho
    public void OnTriggerEnter(Collider col) {

        if (col.tag == "Player" && fluxo == 0) { // começa o fluxo de histórias da recepcionista, NÃO VOLTAR AQUI

            acabou = false;
            fluxo = 1;
            cdLinha = 1.75f;
            AtivarDialogo(0, conversa.linhas.Length);
        }
    }

    // começa o diálogo com a recepcionista
    public void AtivarDialogo(int ini, int fim) {

        quadroFala.gameObject.SetActive(true);
        controleDialogo.ComecarDialogo(conversa, ini, fim);
    }
}
