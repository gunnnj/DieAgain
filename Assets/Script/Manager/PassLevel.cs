using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassLevel : MonoBehaviour
{
    public int level;
    public AudioSource winSound;
    public DataSO dataSO;
    void Start()
    {
        dataSO.currentLevel = level;
    }

    void OnTriggerEnter(Collider other)
    {
        dataSO.currentLevel = level+1;
        ManagerScene.Instance.UpdateMaxLevel();
        winSound.Play();
        if(other.CompareTag("Player")){
            
            if(level<3){
                SceneFade.Instance.FadeToScene("Level "+(level+1));
            }
            else{
                SceneFade.Instance.FadeToScene("SceneWin");
            }
        }
    }
}
