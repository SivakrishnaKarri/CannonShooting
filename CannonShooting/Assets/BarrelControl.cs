using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarrelControl : MonoBehaviour
{
    public GameObject Barrel;
    public Button UpArrowBtn;
    public Button DownArrowBtn;
    public Button LeftArrowBtn;
    public Button RightArrowBtn;
    public int AngleOffset = 4;
    // Start is called before the first frame update
    void Start()
    {
        UpArrowBtn.onClick.AddListener(VerticalUpMovement);
        DownArrowBtn.onClick.AddListener(VerticalDownMovement);
        LeftArrowBtn.onClick.AddListener(HorizontalLeftMovement);
        RightArrowBtn.onClick.AddListener(HorizontalRightMovement);
    }
    private void OnDestroy()
    {
        UpArrowBtn.onClick.RemoveListener(VerticalUpMovement);
        DownArrowBtn.onClick.RemoveListener(VerticalDownMovement);
        LeftArrowBtn.onClick.RemoveListener(HorizontalLeftMovement);
        RightArrowBtn.onClick.RemoveListener(HorizontalRightMovement);
    }
    // Update is called once per frame


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("Right arrow was pressed.");
            HorizontalRightMovement();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("Right arrow was pressed.");
            HorizontalLeftMovement();


        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Up arrow was pressed.");
            VerticalUpMovement();


        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Down arrow was pressed.");
            VerticalDownMovement();
        }

       // Barrel.transform.rotation = Mathf.Clamp(Barrel.transform.rotation.y, - 30,30);


    }


    public void HorizontalRightMovement()
    {
      //  if ((Barrel.transform.localEulerAngles.y <= 30.0f)&&(Barrel.transform.localEulerAngles.y>=-30.0f))
       // {
            Barrel.transform.eulerAngles = new Vector3(Barrel.transform.eulerAngles.x,
                                                          Barrel.transform.eulerAngles.y + AngleOffset,
                                                          Barrel.transform.eulerAngles.z);
        
        //}
    }
    public void HorizontalLeftMovement()
    {
       // if ((Barrel.transform.localEulerAngles.y <= 30.0f) && (Barrel.transform.localEulerAngles.y >= -30.0f))
       // { 
            Barrel.transform.eulerAngles = new Vector3(Barrel.transform.eulerAngles.x,
                                                      Barrel.transform.eulerAngles.y - AngleOffset,
                                                      Barrel.transform.eulerAngles.z);
      //  }
    }
    public void VerticalUpMovement()
    {
        Barrel.transform.eulerAngles = new Vector3(Barrel.transform.eulerAngles.x,
                                                      Barrel.transform.eulerAngles.y,
                                                      Barrel.transform.eulerAngles.z+ AngleOffset);
    }
    public void VerticalDownMovement()
    {
        Barrel.transform.eulerAngles = new Vector3(Barrel.transform.eulerAngles.x,
                                                      Barrel.transform.eulerAngles.y,
                                                      Barrel.transform.eulerAngles.z- AngleOffset);
    }
}
