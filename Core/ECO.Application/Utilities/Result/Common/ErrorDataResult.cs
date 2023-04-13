using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Utilities.Result.Common
{
    public class ErrorDataResult<TData> : DataResult<TData>
    {
        public ErrorDataResult() : base(default, false)
        {

        }
        public ErrorDataResult(TData data) : base(data, false)
        {

        }
        public ErrorDataResult(string message) : base(false, message)
        {

        }
        public ErrorDataResult(TData data, string message) : base(data, false, message)
        {

        }     
    }
}
