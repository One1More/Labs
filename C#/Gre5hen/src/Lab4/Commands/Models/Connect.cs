﻿using Itmo.ObjectOrientedProgramming.Lab4.Contexts.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;

public class Connect : ICommand
{
    private readonly ConnectContext _context;

    public Connect(ConnectContext context)
    {
        _context = context;
    }

    public OperationResult Execute(ref IFileSystem? fileSystem, ref string path)
    {
        if (_context.Mode == "local")
        {
            path = _context.Address;
            fileSystem = new FileSystem.LocalFileSystem(_context.Address);

            return new OperationResult.Success();
        }

        return new OperationResult.Fail();
    }
}