using UnityEngine.UI;

namespace HealthFunctionality.Infrastructure{
    public class HeartBuilder : TestDataBuilder<Heart>{
        private Image image;

        public HeartBuilder(Image image){
            this.image = image;
        }

        public HeartBuilder() : this(An.Image()){
        }

        public override Heart Build(){
            return new Heart(image);
        }

        public HeartBuilder With(Image image){
            this.image = image;
            return this;
        }
    }
}