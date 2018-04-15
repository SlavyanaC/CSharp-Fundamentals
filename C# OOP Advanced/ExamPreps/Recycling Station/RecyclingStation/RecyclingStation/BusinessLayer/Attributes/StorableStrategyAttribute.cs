namespace RecyclingStation.BusinessLayer.Attributes
{
    using System;
    using RecyclingStation.WasteDisposal.Attributes;

    public class StorableStrategyAttribute : DisposableAttribute
    {
        public StorableStrategyAttribute(Type correspondingStratygyType) 
            : base(correspondingStratygyType)
        {
        }
    }
}
