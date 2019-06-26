using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace reusecode.ValueObjct
{
    public interface IParserAsync<TOrigin, TFrom>
    {
        Task<TFrom> Parse(TOrigin origin);
        Task<List<TFrom>> ParseList(IQueryable<TOrigin> origin);

    }
}
