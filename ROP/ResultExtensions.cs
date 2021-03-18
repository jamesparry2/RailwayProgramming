using System;

namespace RopExample.ROP
{
    public static class ResultExtensions
    {
        public static Result<TSuccessNew, TFailure> Bind<TSuccess, TFailure, TSuccessNew>(
            this Result<TSuccess, TFailure> twoTrackInput,
            Func<TSuccess, Result<TSuccessNew, TFailure>> bindFunc)
        {
            return twoTrackInput.IsSuccess
                ? bindFunc(twoTrackInput.Success)
                : Result<TSuccessNew, TFailure>.Failed(twoTrackInput.Failure);
        }
            
        public static Result<TSuccessNew, TFailure> Map<TSuccess, TFailure, TSuccessNew>(
            this Result<TSuccess, TFailure> twoTrackInput,
            Func<TSuccess, TSuccessNew> mapFunc)
        {
            return twoTrackInput.IsSuccess
                ? Result<TSuccessNew, TFailure>.Succeeded(mapFunc(twoTrackInput.Success))
                : Result<TSuccessNew, TFailure>.Failed(twoTrackInput.Failure);
        }

        // Tee is used for dead end functions that returning nothing
        public static Result<TSuccess, TFailure> Tee<TSuccess, TFailure>(
            this Result<TSuccess, TFailure> twoTrackInput,
            Action<TSuccess> teeFunc)
        {
            if (twoTrackInput.IsSuccess)
            {
                teeFunc(twoTrackInput.Success);
            }

            return twoTrackInput;
        }

    }
}
