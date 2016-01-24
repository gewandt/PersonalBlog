using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface ITagService
    {
        bool Create(string name);
        bool Delete(BllTagEntity item);
        BllTagEntity GetById(int id);
    }
}
