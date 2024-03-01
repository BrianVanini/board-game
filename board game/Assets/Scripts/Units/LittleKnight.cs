using UnityEngine;

public class LittleKnight : Unit{
    public LittleKnight(){
        startX = 5;
        startY = 1;

        currentX = 5;
        currentY = 1;

        maxHealth = 10;
        currentHealth = 10;
        damage = 1; 
        attackSpeed = 1;

        moveSpeed = 1;
        resistance = 0.1f;

        shield = 0;
        isAlly = false;
        //traits = [Knight];
    }
}
