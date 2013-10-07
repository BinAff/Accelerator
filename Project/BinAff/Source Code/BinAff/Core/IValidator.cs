using System;
using System.Collections.Generic;

namespace BinAff.Core
{
    public interface IValidator
    {
        List<Message> Validate();
    }
}
