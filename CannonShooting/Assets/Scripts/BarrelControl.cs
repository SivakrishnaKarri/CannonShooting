using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarrelControl : MonoBehaviour
{
    [SerializeField] private GameObject Barrel;
    [SerializeField] private Button UpArrowBtn;
    [SerializeField] private Button DownArrowBtn;
    [SerializeField] private Button LeftArrowBtn;
    [SerializeField] private Button RightArrowBtn;
    [SerializeField] private int AngleOffset = 4;
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
  
    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.RightArrow))|| (Input.GetKeyDown(KeyCode.D)))
        {         
            HorizontalRightMovement();
        }
        if ((Input.GetKeyDown(KeyCode.LeftArrow)) || (Input.GetKeyDown(KeyCode.A)))
        {           
            HorizontalLeftMovement();


        }
        if ((Input.GetKeyDown(KeyCode.UpArrow)) || (Input.GetKeyDown(KeyCode.W)))
        {           
            VerticalUpMovement();


        }
        if ((Input.GetKeyDown(KeyCode.DownArrow)) || (Input.GetKeyDown(KeyCode.S)))
        {           
            VerticalDownMovement();
        }
    }

    
    private void HorizontalRightMovement()
    {
            Barrel.transform.eulerAngles = new Vector3(Barrel.transform.eulerAngles.x,
                                                          Barrel.transform.eulerAngles.y + AngleOffset,
                                                          Barrel.transform.eulerAngles.z);
            
    }
    private void HorizontalLeftMovement()
    {    
            Barrel.transform.eulerAngles = new Vector3(Barrel.transform.eulerAngles.x,
                                                      Barrel.transform.eulerAngles.y - AngleOffset,
                                                      Barrel.transform.eulerAngles.z);     
    }
    private void VerticalUpMovement()
    {
        Barrel.transform.eulerAngles = new Vector3(Barrel.transform.eulerAngles.x,
                                                      Barrel.transform.eulerAngles.y,
                                                      Barrel.transform.eulerAngles.z- AngleOffset);
    }
    private void VerticalDownMovement()
    {
        Barrel.transform.eulerAngles = new Vector3(Barrel.transform.eulerAngles.x,
                                                      Barrel.transform.eulerAngles.y,
                                                      Barrel.transform.eulerAngles.z+ AngleOffset);
    }
}
