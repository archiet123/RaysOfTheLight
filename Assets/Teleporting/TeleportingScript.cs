using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportingScript : MonoBehaviour
{
    
    public int GameScene;
    
    public void ActionFunction()
    {
        StartGame(GameScene);
    }

    public void StartGame(int GameScene)
    {
        SceneManager.LoadScene(GameScene);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player");
        {
          ActionFunction();              
        }
        
    
    } 


}
