using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelChanger : MonoBehaviour
{
    public GameObject Hangpanel;
    public GameObject startPanel;
    public bool isStart = false;

    public void Backgroundchange()
    {
        Hangpanel.SetActive(false);
        startPanel.SetActive(true);
    }
}
