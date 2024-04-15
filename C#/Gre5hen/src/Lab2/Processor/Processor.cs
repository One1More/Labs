using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Sockets;
using Itmo.ObjectOrientedProgramming.Lab2.Videocard;

namespace Itmo.ObjectOrientedProgramming.Lab2.Processor;

public class Processor : ICompatibility<Motherboard.Motherboard>
{
    public Processor(int id, int coreFrequency, int coreNumber, Socket socket, VideoCard? builtInVideocard, IEnumerable<int> availableMemoryFrequencies, int tdp, int powerConsumption)
    {
        Id = id;
        CoreFrequency = coreFrequency;
        CoreNumber = coreNumber;
        Socket = socket;
        BuiltInVideocard = builtInVideocard;
        AvailableMemoryFrequencies = availableMemoryFrequencies.ToList();
        Tdp = tdp;
        PowerConsumption = powerConsumption;
    }

    public static IIdBuilder<IProcessorBuilder> Builder => new ProcessorBuilder();

    public int Id { get; }
    public int CoreFrequency { get; }
    public int CoreNumber { get; }
    public Socket Socket { get; }
    public VideoCard? BuiltInVideocard { get; }
    public IList<int> AvailableMemoryFrequencies { get; }
    public int Tdp { get; }
    public int PowerConsumption { get; }

    public CompareResult Compare(Motherboard.Motherboard workWith)
    {
        if (workWith.Socket.Id != Socket.Id)
            return new CompareResult.Fail(nameof(Motherboard.Motherboard), nameof(Processor), "Processor socket doesnt support.");

        return new CompareResult.Success();
    }

    public class ProcessorBuilder : IProcessorBuilder, IIdBuilder<IProcessorBuilder>
    {
        private int? _id;
        private int? _coreFrequency;
        private int? _coreNumber;
        private Socket? _socket;
        private VideoCard? _builtInVideocard;
        private List<int> _availableMemoryFrequencies;
        private int? _tdp;
        private int? _powerConsumption;

        public ProcessorBuilder()
        {
            _builtInVideocard = null;
            _availableMemoryFrequencies = new List<int>();
        }

        public IProcessorBuilder AddId(int id)
        {
            _id = id;

            return this;
        }

        public IProcessorBuilder AddCoreFrequency(int frequency)
        {
            _coreFrequency = frequency;

            return this;
        }

        public IProcessorBuilder AddCoreNumber(int number)
        {
            _coreNumber = number;

            return this;
        }

        public IProcessorBuilder AddSocket(Socket socket)
        {
            _socket = socket;

            return this;
        }

        public IProcessorBuilder AddVideocard(VideoCard videoCard)
        {
            _builtInVideocard = videoCard;

            return this;
        }

        public IProcessorBuilder AddAvailableMemoryFrequencies(int frequency)
        {
            _availableMemoryFrequencies.Add(frequency);

            return this;
        }

        public IProcessorBuilder AddTdp(int tdp)
        {
            _tdp = tdp;

            return this;
        }

        public IProcessorBuilder AddPowerConsumption(int consumption)
        {
            _powerConsumption = consumption;

            return this;
        }

        public Processor Build()
        {
            return new Processor(
                _id ?? throw new ArgumentNullException(nameof(_id)),
                _coreFrequency ?? throw new ArgumentNullException(nameof(_coreFrequency)),
                _coreNumber ?? throw new ArgumentNullException(nameof(_coreNumber)),
                _socket ?? throw new ArgumentNullException(nameof(_socket)),
                _builtInVideocard,
                _availableMemoryFrequencies,
                _tdp ?? throw new ArgumentNullException(nameof(_tdp)),
                _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)));
        }
    }
}