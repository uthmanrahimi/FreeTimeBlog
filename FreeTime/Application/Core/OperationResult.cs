using System.Collections.Generic;

namespace FreeTime.Web.Application.Core
{
    public class OperationResult
    {

        private readonly static OperationResult _success = new OperationResult { Succeeded = true };
        private List<string> _errors = new List<string>();


        public bool Succeeded { get; protected set; }

        public static OperationResult Success => _success;

        public static OperationResult Failed(params string[] errors)
        {
            var result = new OperationResult { Succeeded = false };
            if (errors != null)
            {
                result._errors.AddRange(errors);
            }

            return result;
        }

        public override string ToString()
        {
            return
                Succeeded ? "Succeeded" :
                $"Failed : {string.Join(',', _errors)}";
        }
    }
}
