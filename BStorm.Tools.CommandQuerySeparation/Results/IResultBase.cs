using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BStorm.Tools.CommandQuerySeparation.Results
{
    public interface IResultBase
    {
        bool IsSuccess { get; }
        bool IsFailure { get; }

        string? ErrorMessage { get; }
        Exception? Exception { get; }
    }
}
