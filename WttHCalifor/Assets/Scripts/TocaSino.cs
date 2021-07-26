using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TocaSino : MonoBehaviour {

    public AudioSource somCampainha;

    private void Update() {

        if (somCampainha.enabled == true && somCampainha.time >= somCampainha.clip.length) {
            somCampainha.enabled = false;
        }
    }

    public void Funcao() {

        if (somCampainha.isPlaying == false) {

        somCampainha.enabled = true;
        somCampainha.Play(0);
        }
    }

    private void OnTriggerStay(Collider colTest) {

        if (colTest.tag == "Player" && Input.GetKeyDown(KeyCode.E)) {

            Funcao();
        }
    }
}
