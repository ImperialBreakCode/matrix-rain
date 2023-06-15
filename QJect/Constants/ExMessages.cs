using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QJect.Constants
{
    internal static class ExMessages
    {
        public const string BindTypeInvalid = "Type of the bind (the implementation) must be a class";
        public const string ServiceTypeInvalid = "Type of service must be an interface or a class";
        public const string ServiceNotRegistered = "Service of type {0} is not registered.";
        public const string ServiceAlreadyRegistered = "Service of type {0} is already registered";
    }
}
