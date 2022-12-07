using System;
using UnityEngine.UI;

namespace HealthSystem{
    public class Heart{
        private const float FILL_PERCENTAGE = 0.5f;

        private Image image;
        public Heart(Image image){
            this.image = image;
        }

        public void Replenish(int numOfPieces){
            if(numOfPieces < 0) throw new ArgumentOutOfRangeException("Can not replenish negative num of heart pieces!");

            this.image.fillAmount += numOfPieces * FILL_PERCENTAGE;
        }

        public void Deplete(int numOfPieces){
            if(numOfPieces < 0) throw new ArgumentOutOfRangeException("Can not deplete negative num of heart pieces!");

            this.image.fillAmount -= numOfPieces * FILL_PERCENTAGE;
        }
    }
}