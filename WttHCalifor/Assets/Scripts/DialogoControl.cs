using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogoControl : MonoBehaviour {

    public Text textoFala;

    private Queue<string> linhasQ;

    private void Start() {

        linhasQ = new Queue<string>();
    }


    public void ComecarDialogo (Dialogo conversa, int ini, int fim) {
        
        // limpa o que tinha na fila
        linhasQ.Clear ();

        // preenche o vetor de linhas com todas as linhas da conversa
        foreach (string linha in conversa.linhas) {

            linhasQ.Enqueue (linha);
        }

        // chamada para o método que anda a conversa
        MostrarProximaLinha ();
    }

    // método para andar as linhas da conversa
    public void MostrarProximaLinha() {

        // se a conversa acabou manda uma mensagem no console e não explode em algo problemático
        if (linhasQ.Count == 0) {
            FimConversa ();
            return;
        }

        // anda uma linha no vetor de linhas tirando ela do vetor
        string linha = linhasQ.Dequeue();
        textoFala.text = linha;

        //Debug.Log (linha);
    }


    public void FimConversa () {

        Debug.Log("conversa já acabou");
    }
}