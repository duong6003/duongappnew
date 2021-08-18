using System;
using System.Collections.Generic;
using System.Text;

namespace DuongAppFirst.Data.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Call Savechange from db context
        /// </summary>
        void Commit();
    }
}
