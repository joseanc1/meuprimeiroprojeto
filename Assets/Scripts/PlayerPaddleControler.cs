using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddleControler : MonoBehaviour
{
    public float speed = 5f;

    public string movementAxiName = "Vertical";

    public bool isPlayer = true;
    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        if (isPlayer)
        {
            spriteRenderer.color = SaveController.Instance.colorPlayer;
        }
    }

    void Update()
    {
        // captura entrada vertical (setas cima e baixo ou W e S)
        float moveInput = Input.GetAxis(movementAxiName);
        
        //Calcula a posição da raquete baseada na entrada  e na velocidade
        Vector3 newPosition = transform.position + Vector3.up * moveInput * speed * Time.deltaTime;
        
        //limitando posição vertical da raquete para que não saia da tela
        newPosition.y = Mathf.Clamp(newPosition.y, -4.5f,4.5f);
        
        //atualiza posição da raquete
        transform.position = newPosition;
    }
}
