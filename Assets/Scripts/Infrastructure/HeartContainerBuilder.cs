using System.Collections.Generic;

namespace HealthFunctionality.Infrastructure{
    public class HeartContainerBuilder : TestDataBuilder<HeartContainer> {
        private List<Heart> hearts;

        public HeartContainerBuilder(List<Heart> hearts){
            this.hearts = hearts;
        }

        public HeartContainerBuilder() : this(new List<Heart>()){
        }

        public override HeartContainer Build()
        {
            return new HeartContainer(hearts);
        }

        public HeartContainerBuilder With(params Heart[] hearts){
            this.hearts.AddRange(hearts);
            return this;
        }
    }
}