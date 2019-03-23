﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadSommet : MonoBehaviour {

    [SerializeField]
    int nbScene;
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "ty")
        {
            SceneManager.LoadScene(nbScene);
        }
    }
}
