using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkills : MonoBehaviour
{
    private PhotonView PV;

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

    public Text dashCDNum;
    public Text sunderCDNum;

    public void Start()
    {
        PV = GetComponent<PhotonView>();

        dashCDImg = GameObject.Find("Skill E/Cooldown").GetComponent<Image>();
        dashCDNum = GameObject.Find("Skill E/CD Num").GetComponent<Text>();
        sunderCDImg = GameObject.Find("Skill RMB/Cooldown").GetComponent<Image>();
        sunderCDNum = GameObject.Find("Skill RMB/CD Num").GetComponent<Text>();

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
        if (!PV.IsMine)
            return;

        if (dashCD > 0)
        {
            dashCDImg.fillAmount = dashCD / dashBaseCD;

            dashCDNum.text = Mathf.CeilToInt(dashCD).ToString();
        
            dashCD -= Time.deltaTime;
        }
        else
        {
            dashCDImg.fillAmount = 0;
            dashCDNum.text = "";
        }

        if (sunderCD > 0)
        {
            sunderCDImg.fillAmount = sunderCD / sunderBaseCD;

            sunderCDNum.text = Mathf.CeilToInt(sunderCD).ToString();

            sunderCD -= Time.deltaTime;
        }
        else
        {
            sunderCDImg.fillAmount = 0;
            sunderCDNum.text = "";
        }
    }

}
