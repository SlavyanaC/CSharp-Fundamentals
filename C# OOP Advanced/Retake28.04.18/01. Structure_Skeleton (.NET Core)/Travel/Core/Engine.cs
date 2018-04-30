namespace Travel.Core
{
    using System;
    using System.Linq;
    using Contracts;
    using Controllers.Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IAirportController airportController;
        private readonly IFlightController flightController;

        public Engine(IReader reader, IWriter writer, IAirportController airportController, IFlightController flightController)
        {
            this.reader = reader;
            this.writer = writer;
            this.airportController = airportController;
            this.flightController = flightController;
        }

        public void Run()
        {
            while (true)
            {
                var input = this.reader.ReadLine();
                if (input == "END")
                {
                    break;
                }
                try
                {
                    var result = this.ProcessCommand(input);
                    this.writer.WriteLine(result);
                }
                catch (InvalidOperationException ex)
                {
                    this.writer.WriteLine("ERROR: " + ex.Message);
                }
            }
        }

        public string ProcessCommand(string input)
        {
            string[] args = input.Split(' ');
            var command = args.First();
            args = args.Skip(1).ToArray();

            string output = string.Empty;
            switch (command)
            {
                case "RegisterPassenger":
                    {
                        var name = args[0];
                        output = this.airportController.RegisterPassenger(name);
                        break;
                    }
                case "RegisterTrip":
                    {
                        var source = args[0];
                        var destination = args[1];
                        var planeType = args[2];
                        output = this.airportController.RegisterTrip(source, destination, planeType);
                        break;
                    }
                case "RegisterBag":
                    {
                        var username = args[0];
                        var bagItems = args.Skip(1);
                        output = this.airportController.RegisterBag(username, bagItems);
                        break;
                    }
                case "CheckIn":
                    {
                        var username = args[0];
                        var tripId = args[1];
                        var bagCheckInIndices = args.Skip(2).Select(int.Parse);
                        output = this.airportController.CheckIn(username, tripId, bagCheckInIndices);
                        break;
                    }
                case "TakeOff":
                    {
                        output = this.flightController.TakeOff();
                        break;
                    }
            }

            return output;
        }
    }
}