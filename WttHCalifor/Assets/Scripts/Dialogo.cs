using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // Para serializar o método

public class Dialogo {
    
    [TextArea (1, 3)] // Dar mais espaço para editar as linhas no inspector do unity

    public string[] linhas;
}

