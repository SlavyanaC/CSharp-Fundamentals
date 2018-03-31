namespace _03BarracksFactory.Core.Commands
{
    using _03BarracksFactory.Contracts;

    public class ReportCommand : Command
    {
        [Inject]
        private IRepository repository;

        public ReportCommand(string[] data, IRepository repository)
            : base(data)
        {
            this.Repository = repository;
        }


        public IRepository Repository
        {
            get => this.repository;
            set => this.repository = value;
        }

        public override string Execute()
        {
            string output = this.Repository.Statistics;
            return output;
        }
    }
}
