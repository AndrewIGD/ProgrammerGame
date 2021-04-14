using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasAnimations : MonoBehaviour
{
    public void DeathScene()
    {
        SceneManager.LoadScene("DeathScene");
    }
}
