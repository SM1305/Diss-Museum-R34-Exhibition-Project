using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextualARButton : MonoBehaviour
{

    public GameObject MenuToOpen;

    public void OpenContextualMenu()
    {
        this.GetComponent<Animator>().SetTrigger("Hide");
        if(MenuToOpen != null)
        {
            MenuToOpen.SetActive(true);
        }
    }
}
