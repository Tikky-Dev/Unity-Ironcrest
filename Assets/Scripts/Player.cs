using System;
using UnityEngine;
public class Player
{
    public int currentHealth{ get; private set;}
    public int maximumHealth{ get; private set;}
    public Player(int health, int maximumHealth = 12){
        if(health < 0) throw new ArgumentOutOfRangeException("Health can not be less then 0");
        if(health > maximumHealth) throw new ArgumentOutOfRangeException("Health can not be greater then maximum health");
        
        this.currentHealth = health;
        this.maximumHealth = maximumHealth;
    }

    public void Heal(int amount){
        var newHealth = Mathf.Min((currentHealth + amount), maximumHealth);
        if(Healed != null){
            Healed(this, new HealedEventArgs(newHealth - currentHealth));
        }
        currentHealth = newHealth;
    }

    public void Damage(int amount){
        var newHealth = Mathf.Max((currentHealth - amount), 0);
        if(Damaged != null){
            Damaged(this, new DamagedEventArgs(currentHealth - newHealth));
        }
        currentHealth = newHealth;
    }

    // Events
    public event EventHandler<HealedEventArgs> Healed;
    public event EventHandler<DamagedEventArgs> Damaged;

    public class HealedEventArgs: EventArgs{
        public int Amount {get; private set;}

        public HealedEventArgs(int amount){
            this.Amount = amount;
        }
    }
    public class DamagedEventArgs: EventArgs{
        public int Amount {get; private set;}

        public DamagedEventArgs(int amount){
            this.Amount = amount;
        }
    }
}
