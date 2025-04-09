using UnityEngine;

public class Management : MonoBehaviour
{
    private bool stop = false;
    public GameObject screen;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(stop == false)
            {
                Time.timeScale = 0;
                screen.SetActive(true);
                stop = true;
            }
            else
            {
                Time.timeScale = 1;
                screen.SetActive(false);
                stop = false;
            }
        }
    }
}
