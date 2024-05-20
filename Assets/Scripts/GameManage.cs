using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public float radius = 5f;

    public int passwordCount = 4;

    public GameObject ComputerPanel;

    public GameObject infoCanvas;

    public bool keyCollected = false;

    public GameObject key;

    public GameObject firstInfoCanvas;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    void Start()
    {
        firstInfoCanvas.SetActive(true);
    }

    void Update()
    {
        Invoke("CloseCanvas", 5f);

    }

    void CloseCanvas()
    {
        firstInfoCanvas.SetActive(false);
    }
}
