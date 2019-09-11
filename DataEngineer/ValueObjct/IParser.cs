using System;
using System.Collections.Generic;
using System.Text;

namespace infra.valueobject
{
    public interface IParser<TOrigin, TFrom>
    {
        TFrom Parse(TOrigin origin);
        List<TFrom> ParseList(List<TOrigin> origin);

    }
}
