using System;
using UnityEngine.UI;

namespace HealthFunctionality{
    public class Heart{
        private const float FILL_PERCENTAGE = 0.5f;

        public static readonly int HEART_PIECES_PER_HEART = 2;
     
        private Image image;

        public int FilledHeartPieces {
            get{ return CalculateFilledHeartPieces(); }
        }
        public int EmptyHeartPieces {
            get{ return (int)(HEART_PIECES_PER_HEART - CalculateFilledHeartPieces()); }
        }

        private int CalculateFilledHeartPieces(){
            return (int)(image.fillAmount * HEART_PIECES_PER_HEART);
        }

        public Heart(Image image){
            this.image = image;
        }
        
        public void Replenish(int numOfHeartPieces){
            if(numOfHeartPieces < 0) throw new ArgumentOutOfRangeException("numOfHeartPieces");
            
            this.image.fillAmount += numOfHeartPieces * FILL_PERCENTAGE;
        }

        public void Deplete(int numOfHeartPieces){
            if(numOfHeartPieces < 0) throw new ArgumentOutOfRangeException("numOfHeartPieces");
            
            this.image.fillAmount -= numOfHeartPieces * FILL_PERCENTAGE; 
        }
    }
}