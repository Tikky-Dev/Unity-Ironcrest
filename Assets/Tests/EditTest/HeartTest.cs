using System;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

using HealthSystem;

public class HeartTest
{
    private Image image;
    private Heart heart;

    [SetUp]
    public void BeforeEveryTest(){
        image = new GameObject().AddComponent<Image>();
        heart = new Heart(image);
    }

    public class TheReplenishMethod : HeartTest{
        [Test]
        public void _0_Set_image_with_0_percent_fill_to_0_fill_percent(){
            image.fillAmount = 0;

            heart.Replenish(0);

            Assert.AreEqual(0f, image.fillAmount);
        }

        [Test]
        public void _1_Set_image_with_0_percent_fill_to_50_percent_fill(){
            image.fillAmount = 0;

            heart.Replenish(1);

            Assert.AreEqual(0.5f, image.fillAmount);
        }

        [Test]
        public void _2_Set_image_with_0_percent_fill_to_100_percent_fill(){
            image.fillAmount = 0;

            heart.Replenish(2);

            Assert.AreEqual(1f, image.fillAmount);
        }

        [Test]
        public void _3_Throw_exception_for_negative_values(){
            Assert.Throws<ArgumentOutOfRangeException>(() => heart.Replenish(-1));
        }
    }

    public class TheDepleteMethod : HeartTest{
        [Test]
        public void _0_Set_Image_with_100_percent_fill_to_100_percent_fill(){
            image.fillAmount = 1f;

            heart.Deplete(0);
            
            Assert.AreEqual(1, image.fillAmount);
        }

        [Test]
        public void _1_Set_Image_with_100_percent_fill_to_50_percent_fill(){
            image.fillAmount = 1f;

            heart.Deplete(1);
            
            Assert.AreEqual(0.5f, image.fillAmount);
        }

        [Test]
        public void _2_Set_Image_with_100_percent_fill_to_0_percent_fill(){
            image.fillAmount = 1f;

            heart.Deplete(2);
            
            Assert.AreEqual(0f, image.fillAmount);
        }

        [Test]
        public void _3_Throw_exception_for_negative_values(){
            Assert.Throws<ArgumentOutOfRangeException>(() => heart.Deplete(-1));
        }
    }
}
