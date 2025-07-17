using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTUDriver
{
    public interface IManagement
    {
        ITag GetTagByIndex(int index);

        ITag GetTagByName(string name);

        List<ITag> GetAllTag();

        bool IsExistTagName(string name);

        bool AddTag(string name, Address address);

        bool AddTag(string name, string addressStr, DataType dataType);

        bool RemoveTag(ITag tag);

        bool RemoveTagByName(string name);

        bool RemoveTagByIndex(int index);
    }
}
