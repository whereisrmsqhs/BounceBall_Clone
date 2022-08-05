using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Mapmake;
    public int stage_index;
    //public SceneManager Scenes;
    public float time;
    public Scene scene;
    // Start is called before the first frame update

   

    public void Start()
    {
        Mapmake = GameObject.Find("MapMaker");
        Mapmake.GetComponent<Mapmake>().Make(0);
        stage_index = 0;
        time = 5f;
    }

    public void NextStage()
    {
        stage_index++;
        StartCoroutine(LoadAsyncScene());
       
        //Mapmake.GetComponent<Mapmake>().Make(stage_index);
    }
    IEnumerator LoadAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(stage_index);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        Mapmake.GetComponent<Mapmake>().Make(stage_index);
    }

}
