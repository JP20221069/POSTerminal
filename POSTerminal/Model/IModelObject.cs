using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSTerminal.Model
{
    public interface IModelObject
    {
        string TableName { get; }

        string ProcedureName { get; }

        string[] ColumnNames { get; }
    }
}
