using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Fade : MonoBehaviour {

    public Transform obj;

    private float velFade = 0.5f;

    private float alfa = 0;

    public bool fadingIn = false, fadingOut = false;

	void Update () {

        // Realiza a ação do fade a força com a tecla Z
        if (Input.GetKeyDown(KeyCode.Z)) {
            comecaFade();
        }

        // Se ativa o fade in
        if (fadingIn == true) {

            alfa += Time.deltaTime * velFade;

            // Caso a tela esteja completamente preta para com o fade in e começa o out
            if (alfa >= 1) {

                fadingIn = false;
                fadingOut = true;
            }

        // Enquanto a tela não está completamente transparente
        }else if (alfa >= 0) { 

            alfa -= Time.deltaTime * velFade;

        // E no fim desativa a tela do fade novamente para o mouse poder interagir com o jogo
        }else {

            fadingOut = false;
            obj.gameObject.SetActive(false);
        }

        //Efetua a mudança de transparência mudando o alfa do material do objeto por meio da variável "alfa" desse método
        obj.GetComponent<Image>().color = new Vector4(0, 0, 0, alfa);
    }

    // Método público para começar o fade in
    public void comecaFade() {
        
        obj.gameObject.SetActive(true);
        fadingIn = true;
    }
}
