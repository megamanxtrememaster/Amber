using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Simple singleton class with a nondestroyable object, here is where we store the vars that should be stored across different scenes, 
/// this object is created in the Loading Scene and it is kept until the game is over
/// </summary
public class GameManager : MonoBehaviour
{

    public static GameManager Instance;


    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadScene("MainMenu");
    }    
}
