using System;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using HealthFunctionality;

public class HeartTest
{
    private Image image;
    private Heart heart;
    
    [SetUp]
    public void BeforeEveryTest(){
        image = new GameObject().AddComponent<Image>();
        heart = new Heart(image);
    } 

    public class TheReplenishMethod: HeartTest{       
        // -------------- Tests --------------
        [Test]
        public void _0_Set_image_with_0_percent_fill_to_0_percent_Fill(){
            image.fillAmount = 0;
            heart.Replenish(0);
            
            Assert.AreEqual(0, image.fillAmount);
        }
        [Test]
        public void _1_Set_image_with_0_percent_fill_to_50_percent_Fill(){
            image.fillAmount = 0;
            heart.Replenish(1);
            
            Assert.AreEqual(0.5f, image.fillAmount);
        }
        [Test]
        public void _2_Set_image_with_50_percent_fill_to_100_percent_Fill(){
            image.fillAmount = 0.5f;
            heart.Replenish(1);
            
            Assert.AreEqual(1f, image.fillAmount);
        }
        [Test]
        public void _3_Throw_exception_for_negative_number_of_heart_pieces(){
            Assert.Throws<ArgumentOutOfRangeException>(() => heart.Replenish(-1));
        }
        // -------------- Tests --------------       
        
        
    }

    public class TheDepleteMethod: HeartTest{
        // -------------- Tests --------------
        [Test]
        public void _0_Set_image_with_100_percent_fill_to_100_percent_Fill(){            
            heart.Deplete(0);

            Assert.AreEqual(1, image.fillAmount);
        }
        [Test]
        public void _1_Set_image_with_100_percent_fill_to_50_percent_Fill(){            
            image.fillAmount = 1;
            heart.Deplete(1);

            Assert.AreEqual(0.5, image.fillAmount);
        }
        [Test]
        public void _2_Set_image_with_50_percent_fill_to_0_percent_Fill(){            
            image.fillAmount = 0.5f;
            heart.Deplete(2);

            Assert.AreEqual(0f, image.fillAmount);
        }
        [Test]
        public void _3_Throw_exception_for_negative_number_of_heart_pieces(){
            Assert.Throws<ArgumentOutOfRangeException>(() => heart.Deplete(-1));
        }
        // -------------- Tests --------------
    }

    public class FilledHeartPiecesHeatPiecesProperty : HeartTest{
        // -------------- Tests --------------
        [Test]
        public void _0_Image_Fill_at_0_percent_Is_0_heart_pieces(){
            image.fillAmount = 0;

            Assert.AreEqual(0, heart.FilledHeartPieces);
        }
        [Test]
        public void _1_Image_Fill_at_50_percent_Is_1_heart_pieces(){
            image.fillAmount = 0.5f;

            Assert.AreEqual(1, heart.FilledHeartPieces);
        }
        [Test]
        public void _2_Image_Fill_at_100_percent_Is_4_heart_pieces(){
            image.fillAmount = 1f;

            Assert.AreEqual(2, heart.FilledHeartPieces);
        }
        // -------------- Tests --------------
    }

    public class TheEmptyHeartPiecesProperty : HeartTest{
        [Test]
        public void _0_Image_with_100_percent_fill_has_0_empty_pieces(){
            
            image.fillAmount = 1;
            
            Assert.AreEqual(0, heart.EmptyHeartPieces);
        }
        [Test]
        public void _1_Image_with_75_percent_fill_has_1_empty_pieces(){
            
            image.fillAmount = 0.75f;
            
            Assert.AreEqual(1, heart.EmptyHeartPieces);
        }
    }
}
