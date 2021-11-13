﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour
{
    public Button jugar;
    public Button salir;

    // Start is called before the first frame update
    void Start()
    {
        Button jugarBtn = jugar.GetComponent<Button>();
        jugarBtn.onClick.AddListener(IrJugar); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IrJugar(){
        SceneManager.LoadScene("PruebaChiguiro");
    }
}
