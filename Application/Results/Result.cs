using System.Collections.Generic;

namespace SV_backend.Application.Results
{
    public class Result
    {
        public bool IsSuccess { get; init; }
        public IEnumerable<string>? Errors { get; init; }
        public int? StatusCode { get; init; }

        public static Result Success(int? statusCode = 200) => new() { IsSuccess = true, StatusCode = statusCode };
        public static Result Fail(string error, int statusCode = 400) => new() { IsSuccess = false, Errors = new[] { error }, StatusCode = statusCode };
        public static Result Fail(IEnumerable<string> errors, int statusCode = 400) => new() { IsSuccess = false, Errors = errors, StatusCode = statusCode };
    }

    public class Result<T> : Result
    {
        public T? Value { get; init; }

        public static Result<T> Success(T value, int? statusCode = 200) => new() { IsSuccess = true, Value = value, StatusCode = statusCode };
        public static new Result<T> Fail(string error, int statusCode = 400) => new() { IsSuccess = false, Errors = new[] { error }, StatusCode = statusCode };
        public static new Result<T> Fail(IEnumerable<string> errors, int statusCode = 400) => new() { IsSuccess = false, Errors = errors, StatusCode = statusCode };
    }
}
