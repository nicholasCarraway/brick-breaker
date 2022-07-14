using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButtonBehavior : MonoBehaviour
{
    [SerializeField] MenuController menuController;
    [SerializeField] SceneNames sceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadLevel()
    {
        menuController.loadLevel(sceneName.ToString());
    }
}
