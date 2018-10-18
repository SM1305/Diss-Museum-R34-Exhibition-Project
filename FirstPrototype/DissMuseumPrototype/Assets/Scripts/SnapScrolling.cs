using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnapScrolling : MonoBehaviour
{
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
    public int selectedPanel;


    void Start ()
    {
        contentRect = GetComponent<RectTransform>();

        panelArray = new GameObject[panelCount];
        panelPosition = new Vector2[panelCount];

        panelScale = new Vector2[panelCount];

        for (int i = 0; i < panelCount; i++)
        {
            panelArray[i] = Instantiate(panelPrefab[i], transform, false);
            if (i == 0) continue;
            panelArray[i].transform.localPosition = new Vector2(panelArray[i-1].transform.localPosition.x + panelPrefab[i].GetComponent<RectTransform>().sizeDelta.x + panelOffset, panelArray[i].transform.localPosition.y);

            panelPosition[i] = -panelArray[i].transform.localPosition;
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

                selectedPanel = i;
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

        contentVector.x = Mathf.SmoothStep(contentRect.anchoredPosition.x, panelPosition[selectedPanel].x, snapSpeed * Time.deltaTime);
        contentRect.anchoredPosition = contentVector;
	}

    public void Scrolling(bool scroll)
    {
        isScrolling = scroll;
        if (scroll) scrollRect.inertia = true;
    }
}
