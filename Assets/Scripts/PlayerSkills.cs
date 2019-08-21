using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    [SerializeField]
    float dashBaseCD = 4;
    [SerializeField]
    float dashCD = 0;
    [SerializeField]
    float sunderBaseCD = 4;
    [SerializeField]
    float sunderCD = 0;


    public bool CheckSkillCD(string skill)
    {
        switch(skill)
        {
            case "dash":
                if (dashCD <= 0)
                {
                    dashCD = dashBaseCD;
                    return true;
                }
                return false;
            case "sunder":
                if (sunderCD <= 0)
                {
                    sunderCD = sunderBaseCD;
                    return true;
                }
                return false;
            default:
                return false;
        }
    }

    private void Update()
    {
        if (dashCD > 0)
        {
            dashCD -= Time.deltaTime;

        }

        if (sunderCD > 0)
        {
            sunderCD -= Time.deltaTime;
        }
    }

}
