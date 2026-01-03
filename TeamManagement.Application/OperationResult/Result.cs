using System;
using System.Collections.Generic;
using System.Text;

namespace TeamManagement.Application.OperationResult
{
    public class Result
    {
        public virtual bool IsSuccess { get; set; }
        public bool IsFailure => !IsSuccess;
        public Error? Error { get; set; }

        protected Result(bool isSuccess, Error? error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Success() => new(true, null);

        public static Result Fail(Error error) => new(false, error);
    }
}
