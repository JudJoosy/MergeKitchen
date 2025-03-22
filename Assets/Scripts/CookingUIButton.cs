using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookingUIButton : MonoBehaviour
{
    public Button cookButton;

    private void Start()
    {
        cookButton.onClick.AddListener(() => CookingManager.Instance.CookDish());
    }
}
