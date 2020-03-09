using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using PathCreation.Examples;

public class SpawnManager : MonoBehaviour
{
    public List<WaveData> waves;
    public GameObject spawned_agent;
    private PathCreator[] path_list;
    private float time_interval;
    private float time_wait;
    private int num_toSpawn;
    private int current_num;
    private int current_wave;
    private void Start()
    {
        current_wave = 0;
        current_num = 0;
        LoadWaveData(current_wave);

        InvokeRepeating("Spawn", time_wait, time_interval);
    }

    void Spawn()
    {
        if (current_num >= num_toSpawn)
        {
            //used to stop spawning?
            CancelInvoke("Spawn");
            Debug.Log("Cancel invoke");
        }
        else
        {
            //randomly choose a path starting from the same point
            int path_number = Random.Range(0, path_list.Length);
            PathCreator path_chosen = path_list[path_number];
            //Instantiate an agent at the start point
            Vector3 init_position = path_chosen.path.GetPoint(0);
            Quaternion init_rotation = path_chosen.path.GetRotation(0f);
            GameObject agent = Instantiate(spawned_agent, init_position, init_rotation);
            //Attach the agent to the path
            agent.GetComponent<PathFollower>().pathCreator = path_chosen;
            current_num++;

            if(current_num == num_toSpawn)
            {
                //Debug.Log("Current num = to spawn num");
                //Debug.Log(current_wave + 1 + " " + waves.Count);
                CancelInvoke("Spawn");
                if(current_wave + 1 <= waves.Count - 1)
                {
                    //Debug.Log("!?");
                    current_wave++;
                    LoadWaveData(current_wave);
                    InvokeRepeating("Spawn", time_wait, time_interval);
                } 
            }
        }
    }

    void LoadWaveData(int i)
    {
        path_list = waves[i].paths;
        time_wait = waves[i].wait;
        time_interval = waves[i].interval;
        num_toSpawn = waves[i].qty;
        //initialize
        current_num = 0;
        Debug.Log("Load wave " + i);
    }
}
