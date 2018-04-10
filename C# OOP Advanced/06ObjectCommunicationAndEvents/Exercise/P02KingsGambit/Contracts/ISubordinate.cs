namespace P02KingsGambit.Contracts
{
    public interface ISubordinate : INameable, IKillable
    {
        string Action { get; }

        void ReactToAttack();
    }
}