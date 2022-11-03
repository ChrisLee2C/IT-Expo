using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Displays : MonoBehaviour
{
    public List<Sprite> textures;
    private List<string> primaryThumbnails;
    private List<string> secondaryThumbnails;
    private Image displayTexture;
    private DisplayButton[] buttons;

    void Awake()
    {
        buttons = DestinationSort(FindObjectsOfType<DisplayButton>());
        foreach (DisplayButton displayButton in buttons)
        {
            int index = GetVideoIndex(displayButton.gameObject);
            SetImage(index);
        }
    }
    
    private int GetVideoIndex(GameObject index) { return index.transform.parent.parent.GetSiblingIndex(); }

    private void SetImage(int index)
    {
        displayTexture = buttons[index - 1].GetComponent<Image>();
        displayTexture.sprite = textures[index - 1];
    }

    DisplayButton[] DestinationSort(DisplayButton[] sortedButtons)
    {
        sortedButtons = sortedButtons.OrderBy(button => button.transform.parent.parent.GetSiblingIndex()).ToArray();
        return sortedButtons;
    }
}
