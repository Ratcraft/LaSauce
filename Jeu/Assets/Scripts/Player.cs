using UnityEngine.Networking;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int playerHp;
    private int playerdmg;
    private int maxplayerhp;
    private int speed;

    public int GetPlayerHp => playerHp;
    public int GetPlayerDmg => playerdmg;

    bool PlayerDead = false;


    public Player(int hpmax)
    {
        this.maxplayerhp = hpmax;
        this.playerHp = maxplayerhp;
        this.speed = 10;
    }


    public void Damage(int dmg)
    {
        playerHp -= dmg;
        if (!PlayerDead)
        {
            if (playerHp <= 0)
            {
                playerHp = 0;
                PlayerDead = true;
                Debug.Log("Dead");
            }
        }
    }

    public void Heal(int heal)
    {
        playerHp += heal;
        if (playerHp > maxplayerhp)
            playerHp = maxplayerhp;
    }

}