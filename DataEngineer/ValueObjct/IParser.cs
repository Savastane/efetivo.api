using System;
using System.Collections.Generic;
using System.Text;

namespace reusecode.ValueObjct
{
    public interface IParser<TOrigin, TFrom>
    {
        TFrom Parse(TOrigin origin);
        List<TFrom> ParseList(List<TOrigin> origin);

    }
}
