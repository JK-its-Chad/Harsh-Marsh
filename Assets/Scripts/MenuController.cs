using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

    public List<Button> buttons;
    public Button Selected;
    public GameObject selector;
    float moveTimer = 0;
    int selectedIndex = 0;

    private void Start()
    {
        buttons[0].Select();
        Selected = buttons[0];
    }

    void Update ()
    {
        moveTimer -= Time.deltaTime;

        if (Input.GetButtonDown("Fire1"))
        {
            Selected.onClick.Invoke();
        }

        if(Input.GetAxis("Vertical") >= 0.95 && moveTimer <= 0)
        {
            if(Selected == buttons[0])
            {
                Selected = buttons[buttons.Count - 1];
                selectedIndex = buttons.Count - 1;
            }
            else
            {
                selectedIndex--;
                Selected = buttons[selectedIndex];
            }
            moveTimer = 0.2f;
        }

        if (Input.GetAxis("Vertical") <= -0.95 && moveTimer <= 0)
        {
            if (Selected == buttons[buttons.Count - 1])
            {
                Selected = buttons[0];
                selectedIndex = 0;
            }
            else
            {
                selectedIndex++;
                Selected = buttons[selectedIndex];
            }
            moveTimer = 0.2f;
        }

        selector.transform.localPosition = Selected.transform.localPosition + Vector3.left * 95;
    }
}
