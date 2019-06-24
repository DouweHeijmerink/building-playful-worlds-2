using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//Reloads the scene whenever our player comes into contact with the death zone at the bottom of the game.
public class LevelComplete : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1));
        }
    }
}


