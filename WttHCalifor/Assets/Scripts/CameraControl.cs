using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public float sensib = 5.0f, suavidade = 2.0f;

    private float camX, camY;

    private Vector2 mouseDir, suaveV, mouseDelta;

    private Transform persona;

    // Awake
    void Awake () {

        // Identifica em quem a câmera está presa
        persona = transform.parent;

        // Giro inicial para começar olhando para o lado desejado
        persona.localRotation = Quaternion.AngleAxis(180, persona.up);
    }
	
	// Update
	void Update () {
        
        // Controle de variáveis de movimento do mouse na câmera para possível uso futuro
        if (Cursor.lockState == CursorLockMode.Locked) {

            camX = Input.GetAxisRaw("Mouse X");
            camY = Input.GetAxisRaw("Mouse Y");
        } else {

            camX = camY = 0;
        }
        
        // Movimento do mouse no atual update
        mouseDelta = new Vector2(camX, camY);

        // Suaviza a câmera
        mouseDelta = Vector2.Scale (mouseDelta, new Vector2 (sensib * suavidade, sensib * suavidade));

        // Interpolação linear para dividir entre os updates
        suaveV.x = Mathf.Lerp (suaveV.x, mouseDelta.x, 1.0f / suavidade);
        suaveV.y = Mathf.Lerp (suaveV.y, mouseDelta.y, 1.0f / suavidade);

        // Efetua a suavidade no movimento do mouse antes de efetuar na rotação do personagem
        mouseDir.x += suaveV.x;

        // Efetua a suavidade no movimento do mouse antes de efetuar na rotação da câmera, com limitação de ângulo
        if ((mouseDir.y < 80 && mouseDir.y > -55) || (mouseDir.y >= 80 && suaveV.y < 0) || (mouseDir.y <= -55 && suaveV.y > 0)) {
            
            mouseDir.y += suaveV.y;
            if (mouseDir.y > 80) {

                mouseDir.y = 80;
            }else if (mouseDir.y < -55) {

                mouseDir.y = -55;
            }
        }

        //efetua o movimento do Y do mouse no Y da câmera
        transform.localRotation = Quaternion.AngleAxis(-mouseDir.y, Vector3.right);
        
        //efetua o movimento no X do personagem de acordo com o X do mouse
        persona.localRotation = Quaternion.AngleAxis (mouseDir.x, persona.up);
	}
}
