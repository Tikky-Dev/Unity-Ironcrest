using System;
using NUnit.Framework;

public class PlayerTest
{
    public class TheCurrentHealthProperty{
        // -------------- Tests -------------- 
        [Test]
        public void _0_Health_defaults_to_0(){
            var player = new Player(0);

            Assert.AreEqual(0, player.currentHealth);
        }
        [Test]
        public void _1_Health_defaults_to_1(){
            var player = new Player(1);

            Assert.AreEqual(1, player.currentHealth);
        }
        [Test]
        public void _2_Throws_Exception_when_current_health_less_then_0(){
            Assert.Throws<ArgumentOutOfRangeException>(() => new Player(-1));
        }
        [Test]
        public void _3_Throws_exception_when_current_health_is_greater_then_maximum(){
            Assert.Throws<ArgumentOutOfRangeException>(() => new Player(2,1));
        }
        // -------------- Tests -------------- 
    }

    public class TheHealMethod{
        // -------------- Tests --------------
        [Test]
        public void _0_Healing_0_health_does_nothing(){
            var player = new Player(0);

            player.Heal(0);

            Assert.AreEqual(0, player.currentHealth);
        }
        [Test]
        public void _1_Healing_1_health_increases_health_by_1(){
            var player = new Player(0);

            player.Heal(1);

            Assert.AreEqual(1, player.currentHealth);
        }
        [Test]
        public void _2_Healing_2_health_increases_health_by_2(){
            var player = new Player(3);

            player.Heal(2);

            Assert.AreEqual(5, player.currentHealth);
        }
        [Test]
        public void _3_OverHealing_is_ignored(){
            var player = new Player(0, 1);

            player.Heal(2);

            Assert.AreEqual(1, player.currentHealth);
        }
        // -------------- Tests --------------
    }

    public class TheDamageMethod{
        // -------------- Tests --------------
        [Test]
        public void _0_Damage_0_health_does_nothing(){
            var player = new Player(0);

            player.Damage(0);

            Assert.AreEqual(0, player.currentHealth);
        }
        [Test]
        public void _1_Damage_1_health_decreases_health_by_1(){
            var player = new Player(1);

            player.Damage(1);

            Assert.AreEqual(0, player.currentHealth);
        }
        [Test]
        public void _2_Damage_2_health_decreases_health_by_2(){
            var player = new Player(3);

            player.Damage(2);

            Assert.AreEqual(1, player.currentHealth);
        }
        [Test]
        public void _3_OverKill_is_ignored(){
            var player = new Player(1, 1);

            player.Damage(2);

            Assert.AreEqual(0, player.currentHealth);
        }
        // -------------- Tests --------------
    }

    public class TheHealedEvent{
        // -------------- Tests --------------
        [Test]
        public void _0_Raises_event_on_Heal(){
            var amount = -1;
            var player = new Player(1);

            player.Healed += (sender, args) => {
                amount = args.Amount;
            };

            player.Heal(0);

            Assert.AreEqual(0, amount);
        }
        [Test]
        public void _1_OverHeal_is_ignored(){
            var amount = -1;
            var player = new Player(1,1);

            player.Healed += (sender, args) => {
                amount = args.Amount;
            };

            player.Heal(1);

            Assert.AreEqual(0, amount);
        }
        // -------------- Tests --------------

    }

    public class TheDamagedEvent{
        // -------------- Tests --------------
        [Test]
        public void _0_Raises_event_on_Damage(){
            var amount = -1;
            var player = new Player(1);

            player.Damaged += (sender, args) => {
                amount = args.Amount;
            };

            player.Damage(1);

            Assert.AreEqual(1, amount);
        }
        [Test]
        public void _1_OverKill_is_ignored(){
            var amount = -1;
            var player = new Player(0);

            player.Damaged += (sender, args) => {
                amount = args.Amount;
            };

            player.Damage(1);

            Assert.AreEqual(0, amount);
        }
        // -------------- Tests --------------

    }
}
