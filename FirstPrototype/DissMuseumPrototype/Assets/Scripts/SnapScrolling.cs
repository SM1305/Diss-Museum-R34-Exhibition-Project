using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnapScrolling : MonoBehaviour
{
    public static SnapScrolling instance;

    [Header("Objects")]
    public GameObject[] panelPrefab;
    public ScrollRect scrollRect;

    private GameObject[] panelArray;
    private Vector2[] panelPosition;
    private Vector2[] panelScale;
    private RectTransform contentRect;
    private Vector2 contentVector;

    [Header("Number Bits")]
    public int panelCount = 9;
    public int panelOffset;
    public float snapSpeed;
    public float scaleOffset;
    public float scaleSpeed;
    public float scaleSizeTweak;
    public float swapSnapForce;

    [Header("Useful Bits")]
    public bool isScrolling;
    public int selectedPanelInt;
    public GameObject selectedPanel;


    void Start ()
    {
        instance = this;

        contentRect = GetComponent<RectTransform>();

        panelArray = new GameObject[panelCount];
        panelPosition = new Vector2[panelCount];

        panelScale = new Vector2[panelCount];

        /*for (int i = 0; i < panelCount; i++)
        {
            panelArray[i] = Instantiate(panelPrefab[i], transform, false);
            if (i == 0) continue;
            panelArray[i].transform.localPosition = new Vector2(panelArray[i-1].transform.localPosition.x + panelPrefab[i].GetComponent<RectTransform>().sizeDelta.x + panelOffset, panelArray[i].transform.localPosition.y);

            panelPosition[i] = -panelArray[i].transform.localPosition;
        }*/

        int i = 0;
        Transform lastChild = null;
        foreach (Transform child in transform)
        {
            if (i == 0)
            {
                lastChild = child;
                panelArray[i] = child.gameObject;
                i++;
                continue;
            }
            child.transform.localPosition = new Vector2(lastChild.transform.localPosition.x + child.GetComponent<RectTransform>().sizeDelta.x + panelOffset, child.transform.localPosition.y);

            panelArray[i] = child.gameObject;
            panelPosition[i] = -panelArray[i].transform.localPosition;
            
            i++;
            lastChild = child;
        }
    }


    void FixedUpdate ()
    {
        if (contentRect.anchoredPosition.x >= panelPosition[0].x && !isScrolling || contentRect.anchoredPosition.x <= panelPosition[panelPosition.Length - 1].x && !isScrolling)
        {
            scrollRect.inertia = false;
        }

        float nearestPos = float.MaxValue;

        for (int i = 0; i < panelCount; i++)
        {
            float distance = Mathf.Abs(contentRect.anchoredPosition.x - panelPosition[i].x);
            if (distance < nearestPos)
            {
                nearestPos = distance;

                selectedPanelInt = i;
                selectedPanel = this.transform.GetChild(i).gameObject;
                //Debug.Log(selectedPanel.name);
            }

            float scale = Mathf.Clamp(1 / (distance / panelOffset) * scaleOffset, 0.5f, 1f);
            panelScale[i].x = Mathf.SmoothStep(panelArray[i].transform.localScale.x, scale + scaleSizeTweak, scaleSpeed * Time.fixedDeltaTime);
            panelScale[i].y = Mathf.SmoothStep(panelArray[i].transform.localScale.x, scale + scaleSizeTweak, scaleSpeed * Time.fixedDeltaTime);
            panelArray[i].transform.localScale = panelScale[i];
        }

        float scrollVelocity = Mathf.Abs(scrollRect.velocity.x);
        //Debug.Log(scrollVelocity);
        if (scrollVelocity < swapSnapForce && !isScrolling)
        {
            scrollRect.inertia = false;
        }

        if (isScrolling || scrollVelocity > swapSnapForce)
        {
            return;
        }

        contentVector.x = Mathf.SmoothStep(contentRect.anchoredPosition.x, panelPosition[selectedPanelInt].x, snapSpeed * Time.deltaTime);
        contentRect.anchoredPosition = contentVector;

        foreach (Transform item in this.transform)
        {
            //Debug.Log("WE HAVE FOUUUUNNNDDDD " + item.name);
            if (item.gameObject != selectedPanel)
            {
                if (item.gameObject.GetComponent<Button>())
                {
                    item.gameObject.GetComponent<Button>().interactable = false;
                }
            }
            else
            {
                if (item.gameObject.GetComponent<Button>() && item.GetComponent<ScrollingButton>().targetInt < TargetManager.instance.nextTarget)
                {
                    item.gameObject.GetComponent<Button>().interactable = true;
                }
            }
        }
    }

    public void Scrolling(bool scroll)
    {
        isScrolling = scroll;
        if (scroll) scrollRect.inertia = true;
    }
}
