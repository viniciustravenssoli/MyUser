using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUser.Application;
public class Result
{
    public bool IsSuccessful { get; set; }
    public string Message { get; set; }

    public static Result Success(string message = "Operation completed successfully.")
    {
        return new Result { IsSuccessful = true, Message = message };
    }

    public static Result Failure(string message)
    {
        return new Result { IsSuccessful = false, Message = message };
    }
}
