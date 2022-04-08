using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GM : MonoBehaviour
{
   public float lefttime;
    int stage;
    public Text stagetext;
    public Text lefttext;
    public GameObject over;
    public GameObject player;
    public GameObject camera;
    public camera cam;
    public pink Pink;
    public GameObject pink2;
    bool next;
    private void Awake()
    {
        stage = 1;
        lefttime = 50;
    }
    private void Update()
    {
        stagetext.text = "STAGE :" + stage;
       cam.upspeed = stage * 0.1f + 0.3f;
        lefttime-= Time.deltaTime;
        lefttext.text = "LEFTTIME :" + Mathf.Floor(lefttime);
        if (lefttime == 0)
            gameover();
    }
    public void gameover()
    {
     //   over.SetActive(true);
       // Time.timeScale = 0;
    }
    public void regame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void nextstage()
    {
        if (!next)
        {
            next = true;
            stage++;
            player.transform.position = new Vector3(0, player.transform.position.y + 27, -5);
            camera.transform.position = new Vector3(0, camera.transform.position.y + 30, camera.transform.position.z);
            pink2.transform.position = new Vector3(0, pink2.transform.position.y + 27, -5);
            if (!Pink.isdie)
            {
                Pink.isdie = true;
            }
            else
            {
                pink2.SetActive(true);
            }
        }
        Invoke("offnext", 2f);
    }
    void offnext()
    {
        next = false;
    }
}
