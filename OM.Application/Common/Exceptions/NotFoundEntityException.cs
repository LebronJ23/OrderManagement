using System;
using System.Collections.Generic;
using System.Text;

namespace OM.Application.Common.Exceptions
{
    public class NotFoundEntityException : Exception
    {
        public NotFoundEntityException(string name, object key) : base($"Entity \"{name}\"({key}) not found")
        {

        }
    }
}
