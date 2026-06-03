using UnityEngine;

public class HelpManager : MonoBehaviour
{
    public GameObject helpPanel;

    private bool isOpen;

    private static bool hasShownHelp = false;

    private void Start()
    {
        if (!hasShownHelp)
        {
            helpPanel.SetActive(true);
            Time.timeScale = 0f;

            isOpen = true;
            hasShownHelp = true;
        }
        else
        {
            helpPanel.SetActive(false);
            Time.timeScale = 1f;

            isOpen = false;
        }
    }

    public void ToggleHelp()
    {
        isOpen = !isOpen;

        helpPanel.SetActive(isOpen);

        if (isOpen)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}