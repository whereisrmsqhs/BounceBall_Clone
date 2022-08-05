using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyObject : MonoBehaviour
{
    public static Scene scene;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if(scene.isLoaded)
        {

        }
    }
    
}
