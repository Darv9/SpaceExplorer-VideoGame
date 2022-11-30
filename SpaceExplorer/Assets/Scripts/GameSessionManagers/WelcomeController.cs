using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomeController : MonoBehaviour
{
    public void OnPressEmpezarJugar()
    {
        LevelManager scene = FindObjectOfType<LevelManager>();
        scene.NextScene();
    }
}
