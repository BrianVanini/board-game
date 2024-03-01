using UnityEngine;
public class Knight : Trait{

    // Stats
    public int health;
    public float damage;
    public float attackSpeed;

    public float moveSpeed;
    public float resistance;

    public Knight(){
        description = "Knights have " + damageBuff + " more damage and start combat with " + shield + " more shield";
        damageBuff = 0.5f;
        shield = 2;


    }
}
