﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfomationScreen3dModels : MonoBehaviour
{

    public GameObject activeObject;
    public SnapScrolling collectionMenu;
    public GameObject[] renderTextureObjects;

    public Image[] backgrounds;
    public RawImage[] modelBackgrounds;


    public Image activePanel;
    public Image[] panels;

    public bool batterySaver = false;

    void Update ()
    {
        if (collectionMenu.selectedPanelInt > 0)
        {
            activePanel = panels[collectionMenu.selectedPanelInt - 1];
        }
        if (BatterySaver.batterySaver)
        {
            for (int i = 0; i < panels.Length; i++)
            {
                backgrounds[i].enabled = true;
                modelBackgrounds[i].gameObject.SetActive(false);

                if (panels[i] == activePanel)
                {
                    activeObject = renderTextureObjects[i];
                }

                if (activePanel.isActiveAndEnabled)
                {
                    activeObject.SetActive(false);
                }
                else
                {
                    renderTextureObjects[i].SetActive(false);
                }
            }
        }
        else
        {
            for (int i = 0; i < panels.Length; i++)
            {
                backgrounds[i].enabled = false;
                modelBackgrounds[i].gameObject.SetActive(true);

                if (panels[i] == activePanel)
                {
                    activeObject = renderTextureObjects[i];
                }

                if (activePanel && activePanel.isActiveAndEnabled)
                {
                    activeObject.SetActive(true);
                }
                else
                {
                    renderTextureObjects[i].SetActive(false);
                }
            }
        }
    }
}
