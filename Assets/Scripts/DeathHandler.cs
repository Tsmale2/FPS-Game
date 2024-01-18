using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas GameoverCanvus;
    // Start is called before the first frame update

    private void Start()
    {
        GameoverCanvus.enabled = false;
        Cursor.visible = false;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void HandleDeath()
    {
        GameoverCanvus.enabled = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }

    


        

}

