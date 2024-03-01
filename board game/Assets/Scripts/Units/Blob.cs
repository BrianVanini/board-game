using UnityEngine;

public class Blob : Unit{
    public Blob(){
        startX = 5;
        startY = 9;

        currentX = 5;
        currentY = 9;

        maxHealth = 10;
        currentHealth = 10;
        damage = 2; 
        attackSpeed = 2;

        moveSpeed = 0;
        resistance = 0;

        shield = 0;
        isAlly = false;
    }
}
