using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HealthFunctionality;
using System.Linq;

// For visual testing
public class App : MonoBehaviour
{
    [SerializeField] private List<Image> images;
    [SerializeField] private int amount;
    
    private Heart heart;
    private HeartContainer heartContainer;
    private Player player;


    private void Start() {
        player = new Player(20,20);
        heartContainer = new HeartContainer(
            images.Select(image => new Heart(image)).ToList()
        );

        player.Healed += (sender, args) => heartContainer.Replenish(args.Amount);
        player.Damaged += (sender, args) => heartContainer.Deplete(args.Amount);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            player.Heal(amount);
        }
        if(Input.GetKeyDown(KeyCode.DownArrow)){
            player.Damage(amount);
        }
    }
}
