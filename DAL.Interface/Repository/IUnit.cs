using System;

namespace DAL.Interface.Repository
{
    public interface IUnit : IDisposable
    {
        void Save();
    }
}
