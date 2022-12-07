using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine.UI;
using UnityEngine;

using HealthSystem;

public class HeartContainerTest{

    private Image image;
    private Heart heart;

    [SetUp]
    public void BeforeEveryTest(){
        image = new GameObject().AddComponent<Image>();
    }

    public class TheReplenishMethod : HeartContainerTest{
        [Test]
        public void _0_Set_image_with_0_percent_to_0_percent_fill(){
            image.fillAmount = 0;
            var heart = new Heart(image);

            var heartContainer = new HeartContainer(new List<Heart> {heart});
            heartContainer.Replenish(0);

            Assert.AreEqual(0, image.fillAmount);
        }
        [Test]
        public void _1_Set_image_with_0_percent_to_50_percent_fill(){
            image.fillAmount = 0;
            var heart = new Heart(image);

            var heartContainer = new HeartContainer(new List<Heart> {heart});
            heartContainer.Replenish(1);

            Assert.AreEqual(0.5f, image.fillAmount);
        }
        [Test]
        public void _2_Set_appropriate_image_with_0_percent_to_50_percent_fill(){
            image.fillAmount = 0;
            var heart = new Heart(image);

            var image1 = new GameObject().AddComponent<Image>();
            image1.fillAmount = 1f;

            var heartContainer = new HeartContainer(new List<Heart> {new Heart(image1), heart});
            heartContainer.Replenish(1);

            Assert.AreEqual(0.5f, image.fillAmount);
        }
        

        // To be continued ...
        [Test]
        public void _3_Set_appropriate_image_with_0_percent_to_0_percent_fill(){
            image.fillAmount = 0;
            var heart = new Heart(image);

            var image1 = new GameObject().AddComponent<Image>();
            image1.fillAmount = 0f;

            var heartContainer = new HeartContainer(new List<Heart> {new Heart(image1), heart});
            heartContainer.Replenish(1);

            Assert.AreEqual(0, image.fillAmount);
        }
    }

    public class HeartContainer{
        private readonly List<Heart> hearts;

        public HeartContainer(List<Heart> hearts){
            this.hearts = hearts;
        }

        public void Replenish(int numOfPieces){
            foreach(var heart in hearts){
                heart.Replenish(numOfPieces);
            }
        }
    }
}