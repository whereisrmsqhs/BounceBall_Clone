using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Mapmake;
    public int stage_index;
    public SceneManager Scenes;
    //Mapmake map = new Mapmake();
    // Start is called before the first frame update
    public void Start()
    {
        Mapmake = GameObject.Find("MapMaker");
        Mapmake.GetComponent<Mapmake>().Make(0);
        stage_index = 0;
    }

    public void NextStage()
    {
        stage_index++;
        SceneManager.LoadScene(stage_index);
        Mapmake.GetComponent<Mapmake>().Make(stage_index);
    }
}
