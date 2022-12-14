using UnityEngine;
using UnityEngine.UI;

namespace HealthFunctionality.Infrastructure{

    public class ImageBuilder : TestDataBuilder<Image>
    {
        private float fillAmount;

        public ImageBuilder(float fillAmount){
            this.fillAmount = fillAmount;
        }

        public ImageBuilder() : this(0){
        }

        public override Image Build(){
            var image =  new GameObject().AddComponent<Image>();
            image.fillAmount = fillAmount;
            return image;
        }

        public ImageBuilder WithFillAmount(float fillAmount){
            this.fillAmount = fillAmount;
            return this;
        }
    }
}
