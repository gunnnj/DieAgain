using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    [SerializeField] public DataSO dataSO;
    public AudioSource clickSound;
    public static ManagerScene Instance;

    void Start()
    {
        Instance = this;
    }

    public void Retry(){
        clickSound.Play();
        SceneManager.LoadScene("Level "+dataSO.currentLevel);
    }
    public void SkipLevel(){
        clickSound.Play();
        if(dataSO.currentLevel<3){
            SceneManager.LoadScene("Level "+(dataSO.currentLevel+1));
        }
        else{
            SceneManager.LoadScene("SceneWin");
        }
    }
    public void LoadSceneLevel(int lv){
        clickSound.Play();
        if(lv>dataSO.maxLevelPass) return;
        SceneManager.LoadScene("Level "+lv);
    }

    public void LoadMenu(){
        clickSound.Play();
        SceneManager.LoadScene("SceneLevel");
    }

    public void LoadScenePlay(){
        clickSound.Play();
        SceneManager.LoadScene("ScenePlay");
    }

    public void UpdateMaxLevel(){
        if(dataSO.maxLevelPass<dataSO.currentLevel){
            dataSO.maxLevelPass = dataSO.currentLevel;
        }
    }


}
