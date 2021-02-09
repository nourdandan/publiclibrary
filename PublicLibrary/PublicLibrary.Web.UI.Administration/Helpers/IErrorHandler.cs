using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicLibrary.Web.UI.Administration.Helpers
{
    public interface IErrorHandler
    {
        void HandleErrorException(string message);

        void LogInformation(string message);
        void LogError(string message);
    }
}
