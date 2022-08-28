using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    public List<GameObject> pages;
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private GameObject pagePrefab;
    private GameObject pageParent;
    private GameObject[] destinations;
    private int quotient;
    private int maxButtonNum = 10;
    private int remainder;

    // Start is called before the first frame update
    void Awake()
    {
        destinations = FindObjectOfType<PlayerController>().destinations;
        quotient = 4;//destinations.Length / maxButtonNum;
        remainder = 8;//destinations.Length % maxButtonNum;
        pageParent = GameObject.Find("Pages");
        CreatePage(quotient);
    }
    private void Start() { pageParent.SetActive(false); }

    private void CreatePage(int quotient)
    {
        for (int times = 0; times < quotient; times++)
        {
            GameObject page = Instantiate(pagePrefab, pageParent.transform.localPosition, Quaternion.identity, pageParent.transform);
            page.name = $"Page {times}";
            pages.Add(page);
            RectTransform pageRectTransform = page.GetComponent<RectTransform>();
            pageRectTransform.transform.localPosition = new Vector3(-pageRectTransform.rect.width/2 + pageParent.transform.localPosition.x, -pageRectTransform.rect.height/2 + pageParent.transform.localPosition.y, 0);
            CreateButton(times, page);
        }
    }

    private void CreateButton(int times, GameObject page)
    {
        if (times == quotient - 1)
        {
            for (int iter = 0; iter < remainder; iter++)
            {
                GameObject button = Instantiate(buttonPrefab, page.transform.localPosition, Quaternion.identity, page.transform);
                button.name = $"Button {iter}";
                button.transform.SetSiblingIndex(iter);
                RectTransform buttonRectTransform = button.GetComponent<RectTransform>();
                Vector3 pageTransform = page.transform.localPosition;
                Vector3 pageParentTransform = page.transform.parent.transform.localPosition;
                buttonRectTransform.transform.localPosition = new Vector3(buttonRectTransform.rect.width / 2 + pageTransform.x - pageParentTransform.x,
                    buttonRectTransform.rect.height / 2 - pageTransform.y - pageParentTransform.y/2 - iter * buttonRectTransform.rect.height, 0);
            }
        }
        else
        {
            for (int iter = 0; iter < maxButtonNum; iter++)
            {
                GameObject button = Instantiate(buttonPrefab, page.transform.localPosition, Quaternion.identity, page.transform);
                button.name = $"Button {iter}";
                button.transform.SetSiblingIndex(iter);
                RectTransform buttonRectTransform = button.GetComponent<RectTransform>();
                Vector3 pageTransform = page.transform.localPosition;
                Vector3 pageParentTransform = page.transform.parent.transform.localPosition;
                buttonRectTransform.transform.localPosition = new Vector3(buttonRectTransform.rect.width / 2 + pageTransform.x - pageParentTransform.x,
                    buttonRectTransform.rect.height / 2 - pageTransform.y - pageParentTransform.y/2 - iter * buttonRectTransform.rect.height, 0);
            }
        }
    }
}