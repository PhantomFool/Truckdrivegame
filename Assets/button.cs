using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button : MonoBehaviour
{
    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void OpenURL()
    {
        Application.OpenURL("https://youtu.be/dQw4w9WgXcQ");
    }
}
