using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomePerto : MonoBehaviour {

    public float distSumir;

    private float dist = 100;

    public Transform sumira, outro;

    private Color cor;

    private AudioSource somRisadas;

    void Awake() {

        somRisadas = GetComponent<AudioSource>();
    }

    void Update() {

        // Calcula a distância entre ambos os atores
        dist = Vector3.Distance(outro.position, sumira.transform.position);

        // Pega a cor do renderer do objeto a sumir
        cor = sumira.GetComponent<Renderer>().material.color;
        
        // Redução linear do alfa da cor do objeto
        cor.a = Mathf.Lerp(0, 0.5f, (dist - distSumir));

        // Efetua a mudança do alfa da cor do objeto
        sumira.GetComponent<Renderer>().material.color = cor;
        

        if ((sumira.GetComponent<Renderer>().material.color.a <= 0.1) && (sumira.gameObject.activeSelf == true)) {
            // desliga o objeto que deve sumir
            sumira.gameObject.SetActive(false);

            //toca som de risada
            somRisadas.enabled = true;
            somRisadas.time = 9.2f;
        }
        // desativa o som antes de terminar
        if (somRisadas.enabled == true && somRisadas.time >= somRisadas.clip.length) {

            somRisadas.enabled = false;
        }
    }
}
