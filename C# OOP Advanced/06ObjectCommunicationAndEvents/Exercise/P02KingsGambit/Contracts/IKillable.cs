namespace P02KingsGambit.Contracts
{
    public interface IKillable
    {
        bool IsAlive { get; }

        void Die();
    }
}
