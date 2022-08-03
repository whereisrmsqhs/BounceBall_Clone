using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mapmake : MonoBehaviour
{
    public int stage_num;
    public string block_name;
    public float posX, posY, posZ;
    public int coin_num;
    public int cur_stage;
    public static List<int> total_coins = new List<int>();
    // Start is called before the first frame update
    void Start()
    {

        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("stage");
        coin_num = 1;
        cur_stage = 2;
        for(int i = 0; i < data_Dialog.Count; i++)
        {
            stage_num = (int)data_Dialog[i]["stage"];
            block_name = data_Dialog[i]["object"].ToString();
            posX = float.Parse(data_Dialog[i]["posX"].ToString());
            posY = float.Parse(data_Dialog[i]["posY"].ToString());
            posZ = float.Parse(data_Dialog[i]["posZ"].ToString());

            if (i > 0 && stage_num > (int)data_Dialog[i - 1]["stage"])
            {
                total_coins[stage_num +  1] = coin_num;
                coin_num = 1;
                SceneManager.LoadScene(cur_stage++);
            }

            if (block_name.Equals("coin"))
            {
                coin_num++;
            }

            GameObject object_name = GameObject.Find(block_name);

            if (block_name.Equals("uparrow"))
            {
                Instantiate(object_name, new Vector3(posX, posY, posZ), Quaternion.Euler(0, 0, 90));
            }
            else
                Instantiate(object_name, new Vector3(posX, posY, posZ), Quaternion.identity);
        }

        total_coins[stage_num - 1] = coin_num;  
    }
    
    
}
