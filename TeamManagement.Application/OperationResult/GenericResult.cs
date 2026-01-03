using System;
using System.Collections.Generic;
using System.Text;

namespace TeamManagement.Application.OperationResult
{
    public class Result<T> : Result
    {
        public T? ReturnValue { get; set; }

        private Result(T returnValue) : base(true, null)
        {
            ReturnValue = returnValue;
        }
        private Result(Error? error) : base(false, error) { }
        public static Result<T> Success(T returnValue) => new Result<T>(returnValue);

        public static new Result<T> Fail(Error error) => new Result<T>(error);
    }
}
