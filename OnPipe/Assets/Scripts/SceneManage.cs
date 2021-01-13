using UnityEngine;

public class SceneManage : MonoBehaviour
{
    private bool vic;

    private bool go;

    void Update()
    {
        if(vic || go)
        {
            FindObjectOfType<ScoreController>().Restart();
        }
    }

    public void SetBool(bool vict, bool gameO)
    {
        vic = vict;
        go = gameO;
    }
}
