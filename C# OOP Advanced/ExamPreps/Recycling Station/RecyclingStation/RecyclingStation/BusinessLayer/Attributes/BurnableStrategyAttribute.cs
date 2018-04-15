namespace RecyclingStation.BusinessLayer.Attributes
{
    using RecyclingStation.WasteDisposal.Attributes;
    using System;

    public class BurnableStrategyAttribute : DisposableAttribute
    {
        public BurnableStrategyAttribute(Type correspondingStratygyType)
            : base(correspondingStratygyType)
        {
        }
    }
}
