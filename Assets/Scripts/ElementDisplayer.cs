using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementDisplayer : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text elementTypeText;
    // Update is called once per frame
    void Update()
    {
        elementTypeText.text = "Current Element > " + PlayerController.Instance.GetComponent<IElementHolder>().CurrentElementHeld;
	}
}
