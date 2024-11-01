namespace GameClub.Infrastructure
{
    public class Result {
        public Result(bool isSuccess, Error error)
        {
            if (isSuccess && error != Error.None ||
            !isSuccess && error == Error.None)
            {
                throw new ArgumentException("Invalid error", nameof(error));
            }

            IsSuccess = isSuccess;
            Error = error;
        }
        public Result(bool isSuccess) : this(isSuccess, Error.None) { }
        public bool IsSuccess { get; }

        public bool IsFailure => !IsSuccess;

        public Error Error { get; }
    }
}
