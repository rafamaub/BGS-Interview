using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWorldCanvas : MonoBehaviour
{
    public static PlayerWorldCanvas Instance;
    [SerializeField] private GameObject eKeyTip;

    private void Awake()
    {
        Instance = this;
    }
    public void ShowETip()
    {
        eKeyTip.SetActive(true);
    }

    public void HideETip()
    {
        eKeyTip.SetActive(false);
    }
}
