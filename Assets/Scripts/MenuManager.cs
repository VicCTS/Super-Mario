using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    //funcion para cargar el primer nivel
    public void LoadLVL1()
    {
        SceneManager.LoadScene("Nivel1");
    }
}
