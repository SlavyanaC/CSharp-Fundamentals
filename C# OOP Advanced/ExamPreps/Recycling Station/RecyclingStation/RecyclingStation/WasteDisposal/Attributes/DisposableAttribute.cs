namespace RecyclingStation.WasteDisposal.Attributes
{
    using System;

    /// <summary>
    /// An attribute class, that represents the base of all Disposable Attribute classes.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class DisposableAttribute : Attribute
    {
        private Type correspondingStratygyType;

        public DisposableAttribute(Type correspondingStratygyType)
        {
            this.CorrespondingStratygyType = correspondingStratygyType;
        }

        public Type CorrespondingStratygyType
        {
            get => correspondingStratygyType;
            set => correspondingStratygyType = value;
        }
    }
}
