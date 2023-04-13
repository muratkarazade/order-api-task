using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Utilities.Result.Common
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; set; }
    }
}
