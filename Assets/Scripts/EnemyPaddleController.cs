using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPaddleController : GameManager
{
   private Rigidbody2D rb;
   public float speed = 3f;

   private GameObject ball;
   
   public string movementAxiName = "Vertical2";

   public bool isControlling = false;
   
   public bool isEnemy = true;
   public SpriteRenderer spriteRenderer;

   void Start()
   {
      
      if (isEnemy)
         {
            spriteRenderer.color = SaveController.Instance.colorEnemy;
         }
      
      
      rb = GetComponent<Rigidbody2D>();
      ball = GameObject.Find("Ball"); //encontrar o objeto ball na cena
   }

   private void Update()
   {
      
      //desligando e ligando IA enemy
      if (Input.GetKeyDown(KeyCode.R))
      {
         speed = 5f;

         isControlling = !isControlling;
      }
      
      //enemy IA
      if (!isControlling && ball != null)
      {
         float targetY = Mathf.Clamp(ball.transform.position.y, -4.5f, 4.5f);//limitando posição paddle
         Vector2 targetPosition = new Vector2(transform.position.x, targetY);
         transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed); //move gradualmente para a posição y da bola
      }
      
      //controle manual player 2
      if (isControlling)
      {
         // captura entrada vertical
         float moveInput = Input.GetAxis(movementAxiName);
        
         //Calcula a posição da raquete baseada na entrada  e na velocidade
         Vector3 newPosition = transform.position + Vector3.up * moveInput * speed * Time.deltaTime;
        
         //limitando posição vertical da raquete para que não saia da tela
         newPosition.y = Mathf.Clamp(newPosition.y, -4.5f,4.5f);
        
         //atualiza posição da raquete
         transform.position = newPosition;
      }
   }
}