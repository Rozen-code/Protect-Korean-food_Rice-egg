using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Mode
{
    public string dataName;
    public string[] datas;
}

public class Obstacle : MonoBehaviour
{
    // OT(Obstacle Type)
    [SerializeField]
    public List<Mode> gameData;

    private void Start()
    {
        string getDataName = "A Data";
        for(int index = 0;index < gameData.Count; index++)
        {
            if(getDataName.Equals(gameData[index].dataName))
            {
                for(int jndex = 0; jndex < gameData[index].datas.Length; jndex++)
                {
                    Debug.Log(gameData[index].datas[jndex]);
                }
                    
            }
        }
    }

    public enum RunOT // 1
    {
        SHORT_POOL_OF_WATER,
        LONG_POOL_OF_WATER,
        FASTFOOD_UNDERLING,
        MOLE
    }

    public enum RunAwayOT // 2 
    {
        // 필요시 기입하여 사용
    }

    public enum ClimbingOT // 3
    {

    }

    public enum HitTheMarkOT // 4
    {

    }

    public enum FlipItOT // 5
    {

    }

    public enum GetItOT // 6
    {

    }

    public enum CatchItOT // 7
    {

    }

    public enum HitTheTargetOT // 8
    {

    }

    public enum FFInfor
    {
        TOWNSMEN,
        STUFF_FF,
        STIFF_FF,
        Oil_FF,
        DESSERT_FF,
    }
}
