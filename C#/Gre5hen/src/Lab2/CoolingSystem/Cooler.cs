using System;
using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem;

public class Cooler : ICompatibility<Processor.Processor>, ICompatibility<Motherboard.Motherboard>
{
    public Cooler(int id, IEnumerable<string> supportedSockets, int tdp)
    {
        Id = id;
        SupportedSockets = supportedSockets.ToList();
        Tdp = tdp;
    }

    public static IIdBuilder<ICoolerBuilder> Builder => new CoolerBuilder();

    public int Id { get; }
    public IList<string> SupportedSockets { get; }
    public int Tdp { get; }

    public CompareResult Compare(Processor.Processor workWith)
    {
        if (Tdp < workWith.Tdp)
            return new CompareResult.Fail(nameof(Processor.Processor), nameof(Cooler), "Max TDP is lower then usable.");

        return new CompareResult.Success();
    }

    public CompareResult Compare(Motherboard.Motherboard workWith)
    {
        if (!SupportedSockets.Contains(workWith.Socket.Name))
            return new CompareResult.Fail(nameof(Motherboard.Motherboard), nameof(Cooler), "Cooler doesnt support motherboard socket");

        return new CompareResult.Success();
    }

    private class CoolerBuilder : ICoolerBuilder, IIdBuilder<ICoolerBuilder>
    {
        private int? _id;
        private List<string> _supportedSockets;
        private int? _tdp;

        public CoolerBuilder()
        {
            _supportedSockets = new List<string>();
        }

        public ICoolerBuilder AddId(int id)
        {
            _id = id;

            return this;
        }

        public ICoolerBuilder AddSocket(string socket)
        {
            _supportedSockets.Add(socket);

            return this;
        }

        public ICoolerBuilder AddTDP(int tdp)
        {
            _tdp = tdp;

            return this;
        }

        public Cooler Build()
        {
            return new Cooler(
                _id ?? throw new ArgumentNullException(nameof(_id)),
                _supportedSockets,
                _tdp ?? throw new ArgumentNullException(nameof(_tdp)));
        }
    }
}