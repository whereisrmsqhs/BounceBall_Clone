using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mapmake : MonoBehaviour
{
    public GameObject Ball;
    public int stage_num;
    public string block_name;
    public float posX, posY, posZ;
    public int coin_num;
    public int cur_stage;
    public static int[] total_coins = new int[100];
    public Scene scene;

    public void Awake()
    {
        Ball = GameObject.Find("Ball");

    }
    // Start is called before the first frame update
    public void Make(int stage)
    {
        
        Debug.Log("Build Map");
        // ¿œ¥‹ √π intro æ¿¿∫ Ω∫≈µ...
        cur_stage = stage;
        coin_num = 0;
        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("stage");

        for(int i = 0; i < data_Dialog.Count; i++)
        {
            stage_num = (int)data_Dialog[i]["stage"];
            if (stage_num != cur_stage)
                continue;
            block_name = data_Dialog[i]["object"].ToString();
            posX = float.Parse(data_Dialog[i]["posX"].ToString());
            posY = float.Parse(data_Dialog[i]["posY"].ToString());
            posZ = float.Parse(data_Dialog[i]["posZ"].ToString());

            if (block_name.Equals("coin"))
            {
                coin_num++;
            }
            if (block_name.Equals("ball"))
            {
                Ball.transform.position = new Vector3(posX, posY, posZ);
                continue;
            }
            //GameObject object_name = GameObject.Find(block_name);

            if (block_name.Equals("uparrow"))
            {
                Instantiate(Resources.Load<GameObject>( block_name), new Vector3(posX, posY, posZ), Quaternion.Euler(0, 0, 90));
            }
            else
            {
                Instantiate(Resources.Load<GameObject>( block_name), new Vector3(posX, posY, posZ), Quaternion.identity);
            }
        }

        total_coins[stage] = coin_num;  
    }
    
}
