using NUnit.Framework;
using UnityEngine.UI;
using HealthFunctionality;
using HealthFunctionality.Infrastructure;

public class HeartContainerTest{
    
    public class TheReplenishMethod{
        private Image target;
        private Heart heart;

        [SetUp]
        public void BeforeEveryTest(){
            target = (Image) An.Image();
        }


        // -------------- Tests --------------
        [Test]
        public void _0_Set_Image_With_0_precent_Fill_to_0_precent_fill(){
            var heart = A.Heart().With(target);
            var heartContainer =(HeartContainer) A.HeartContainer()
                .With(heart);

            heartContainer.Replenish(0);

            Assert.AreEqual(0, target.fillAmount);
        }
        [Test]
        public void _1_Set_Image_With_0_precent_Fill_to_50_precent_fill(){
            var heart = A.Heart().With(target);
            var heartContainer = (HeartContainer) A.HeartContainer().With(heart);

            heartContainer.Replenish(1);

            Assert.AreEqual(0.5f, target.fillAmount);
        }
        [Test]
        public void _2_Empty_Hearts_are_replenished(){
            var heartContainer = (HeartContainer) A.HeartContainer()
                .With(
                    A.Heart().With(An.Image().WithFillAmount(1)),
                    A.Heart().With(target)
                );

            heartContainer.Replenish(1);

            Assert.AreEqual(0.5f, target.fillAmount);
        }
        [Test]
        public void _3_Hearts_are_replenished_in_order(){
            var heartContainer = (HeartContainer) A.HeartContainer()
                .With(
                    A.Heart(),
                    A.Heart().With(target)
                );

            heartContainer.Replenish(1);

            Assert.AreEqual(0, target.fillAmount);
        }
        [Test]
        public void _4_Distribute_heart_pieces_Across_unfilled_hearts(){
            ((HeartContainer) A.HeartContainer()
                .With(
                    A.Heart()
                        .With(An.Image().WithFillAmount(0.5f)),
                    A.Heart()
                        .With(target)
                )
            ).Replenish(2);

            Assert.AreEqual(0.5f, target.fillAmount);
        }
        // -------------- Tests --------------

    }

    public class TheDepleteMethod{
        private Image target;

        [SetUp]
        public void BeforeEveryTest(){
            target = (Image) An.Image().WithFillAmount(1f);
        }

        // -------------- Tests --------------
        [Test]
        public void _0_Set_full_Image_to_100_percent_fill(){
            ((HeartContainer) A.HeartContainer()
                .With(
                    A.Heart().With(target)
                )
            ).Deplete(0);

            Assert.AreEqual(1f, target.fillAmount);
        }
        [Test]
        public void _1_Set_100_percent_fill_Image_to_50_percent_fill(){
            ((HeartContainer) A.HeartContainer()
                .With(
                    A.Heart().With(target)
                )
            ).Deplete(1);

            Assert.AreEqual(0.5f, target.fillAmount);
        }
        [Test]
        public void _2_Set_100_percent_fill_Image_to_50_percent_fill_with_multiple_Hearts(){
            ((HeartContainer) A.HeartContainer()
                .With(
                    A.Heart().With(target),
                    A.Heart().With(An.Image().WithFillAmount(0.5f))
                )
            ).Deplete(2);

            Assert.AreEqual(0.5f, target.fillAmount);
        }
        // -------------- Tests --------------
        
    }
    
}