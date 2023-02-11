using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReload : MonoBehaviour
{
     
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            AsyncOperation unloadRooms = SceneManager.UnloadSceneAsync("Assets/Scenes/GamingLevel/BasementBasic1");
            RoomController.instance.RoomsRemover();
           // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}//NOT USED. Testing purposes

