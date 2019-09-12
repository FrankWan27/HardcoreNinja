using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public Image dashCDImg;
    public Image sunderCDImg;

    public void Start()
    {
        dashCDImg = GameObject.Find("Skill E/Cooldown").GetComponent<Image>();
        sunderCDImg = GameObject.Find("Skill RMB/Cooldown").GetComponent<Image>();
    }

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
            dashCDImg.fillAmount = dashCD / dashBaseCD;
            dashCD -= Time.deltaTime;
        }

        if (sunderCD > 0)
        {
            sunderCDImg.fillAmount = sunderCD / sunderBaseCD;
            sunderCD -= Time.deltaTime;
        }
    }

}
