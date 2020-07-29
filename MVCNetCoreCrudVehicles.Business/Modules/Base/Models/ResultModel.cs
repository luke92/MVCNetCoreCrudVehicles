using System.Collections.Generic;


namespace MVCNetCoreCrudVehicles.Business.Modules.Base.Models
{
    public enum OperationResult
    {
        Ok,
        Error
    }

    public class ResultModel<T>
    {
        public OperationResult Result { get; set; }
        public T Data { get; set; }
        public IEnumerable<ErrorModel> Errors { get; set; }

        public ResultModel(OperationResult result, T data = default(T))
        {
            Result = result;
            Data = data;
        }

        public ResultModel(OperationResult result, IEnumerable<ErrorModel> errors)
        {
            Result = result;
            Errors = errors;
        }

        public ResultModel()
        {
        }
    }

    public class ErrorModel
    {
        public string Source { get; set; }
        public string Message { get; set; }

        public ErrorModel(string source, string message)
        {
            Source = source;
            Message = message;
        }
    }

    public class ErrorResultModel<T> : ResultModel<T>
    {
        public ErrorResultModel(IEnumerable<ErrorModel> errors)
            : base(OperationResult.Error, errors)
        { }

        public ErrorResultModel(string message)
            : base(OperationResult.Error, new ErrorModel[] { new ErrorModel("Operation", message) })
        { }


    }

    public class SuccessResultModel<T> : ResultModel<T>
    {
        public SuccessResultModel(T data)
            : base(OperationResult.Ok, data)
        { }
    }
}
