using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botoes : MonoBehaviour {

    public Transform botaoSairPortaSim, botaoSairPortaNao, canvasSair;

    public void BotaoPause () {

    }

    public void BotaoCertezaPortaNao () {

        canvasSair.gameObject.SetActive(false);
    }

    public void BotaoSair() {

        Application.Quit();
    }
}
