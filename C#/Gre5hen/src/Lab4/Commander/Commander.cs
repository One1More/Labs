using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commander;

public class Commander
{
   private IFileSystem? _fileSystem;
   private string _relativePath;

   public Commander()
   {
      _relativePath = string.Empty;
   }

   public OperationResult RunCommand(HandleResult handleResult)
   {
      if (handleResult is HandleResult.Success res)
      {
         return res.Command.Execute(ref _fileSystem, ref _relativePath);
      }
      else
      {
         return new OperationResult.Fail();
      }
   }
}