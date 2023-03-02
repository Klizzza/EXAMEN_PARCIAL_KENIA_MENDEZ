using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EXAMEN_PARCIAL_MENDEZ_KENIA : MonoBehaviour
{
    // Variables

    // Estas variables guardar�n los n�meros random generados por la computadora
    private int suma;
    private int num_Suma_1;
    private int num_Suma_2;

    // Estas variables controlar�n el aspecto UI en unity
    [SerializeField] private TMP_Text num1_UI;
    [SerializeField] private TMP_Text num2_UI;
    [SerializeField] private TMP_Text operando_UI;
    [SerializeField] private TMP_Text resultado_UI;
    [SerializeField] private TMP_Text vida_UI;
    [SerializeField] private TMP_InputField respuesta_usuario_InFi;

    private int num_Usuario;
    private int vida;
    private int contador;

    // Start is called before the first frame update
    void Start()
    {
        Generador_Ecuaciones();
        vida = 100;
        vida_UI.text = "Vida: " + vida;
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void Generador_Numeros() // Funci�n que crear� los n�meros random para las ecuaciones
    {
        num_Suma_1 = Random.Range(0, 11);
        Debug.Log("El primer numero es: " + num_Suma_1); // Impreso en consola solamente porque quiero comprobar si se gener� adecuadamente
        num_Suma_2 = Random.Range(0, 11);
        Debug.Log("El segundo numero es: " + num_Suma_2);

        suma = num_Suma_1 + num_Suma_2;
        Debug.Log(suma);
    }
    private void Generador_Ecuaciones() // Funci�n que producir� nuevas ecuaciones
    {
        Generador_Numeros();

        num1_UI.text = num_Suma_1.ToString();
        operando_UI.text = "+";
        num2_UI.text = num_Suma_2.ToString();

    }

    public void Analisis() // Funcion que convertir� el n�mero del InputField para la comprensi�n del script y comparar� resultados entre jugador y maquina
    {
        int.TryParse(respuesta_usuario_InFi.text, out num_Usuario);
        Debug.Log(num_Usuario);

        if(num_Usuario == suma)
        {
            resultado_UI.text = "Correcto";
        }
        else
        {
            resultado_UI.text = "Incorrecto";
        }
    }

    public void Siguiente_Ecuacion() // Funci�n que mostrar� la siguiente ecuaci�n al jugador si este tiene la respuesta correcta
    {
        if (resultado_UI.text == "Correcto")
        {
            contador = contador + 1;
            Generador_Ecuaciones();
        }
    }

    public void Vida() // Vida porque no supe como hacer tiempo :(
    {
        if (resultado_UI.text == "Incorrecto")
        {
            vida = vida - 10;
            vida_UI.text = "Vida: " + vida;
        }
    }

    public void Fin() // Esta funci�n revelar� al usuario cu�ntas ecuaciones solucion� al final
    {
        if (vida == 0)
        {
            num1_UI.text = "Pudiste solucionar " + contador + " ecuaciones";
            num2_UI.text = "";
            operando_UI.text = "";
        }
    }
    public void Replay() // Funci�n para reiniciar el juego
    {
        SceneManager.LoadScene(0);
    }
}
