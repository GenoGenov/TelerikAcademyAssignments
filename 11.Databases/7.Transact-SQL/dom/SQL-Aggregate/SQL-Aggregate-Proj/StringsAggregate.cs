using System;
using System.Data.SqlTypes;
using System.Text;

using Microsoft.SqlServer.Server;

[Serializable]
[SqlUserDefinedAggregate(
    Format.UserDefined, //use clr serialization to serialize the intermediate result
    IsInvariantToNulls = true, //optimizer property
    IsInvariantToDuplicates = false, //optimizer property
    IsInvariantToOrder = false, //optimizer property
    MaxByteSize = 8000) //maximum size in bytes of persisted value
]
public struct MergeStrings:IBinarySerialize
{
    private StringBuilder result;

    public void Init()
    {
        this.result = new StringBuilder();
    }

    public void Accumulate(SqlString value)
    {
        if (value.IsNull)
        {
            return;
        }

        this.result.Append(value.ToString());
        this.result.Append(",");
    }

    public void Merge(MergeStrings value)
    {
        this.Accumulate(value.ToString());
    }

    public SqlString Terminate()
    {
        return new SqlString(this.result.ToString().Trim(','));
    }

    public void Read(System.IO.BinaryReader r)
    {
        this.result = new StringBuilder(r.ReadString());
    }

    public void Write(System.IO.BinaryWriter w)
    {
        w.Write(this.result.ToString());
    }
}