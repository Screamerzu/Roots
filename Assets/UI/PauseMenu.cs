using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenu : SceneManagement, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        pausePanel.SetActive(true);
    }
}
