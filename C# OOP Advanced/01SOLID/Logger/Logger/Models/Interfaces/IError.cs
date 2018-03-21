namespace Logger.Models.Interfaces
{
    using System;

    public interface IError : ILevelable
    {
        DateTime DateTime { get; }

        string Mesage { get; }
    }
}