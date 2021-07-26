using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaQuarto203Tranca : MonoBehaviour {
    
    public GameObject obj;

    public Component ativa;

    private void OnTriggerEnter(Collider col) {
        // se existir uma chave
        if (obj != null) {
            //e o jogador estiver segurando essa chave ao entrar no gatilho, a chave destrói e a porta ativa
            if (col.gameObject == obj.gameObject) {
                ativa.GetComponent<PortaFunc>().enabled = true;
                Destroy(obj);
            }
        }
    }
}
