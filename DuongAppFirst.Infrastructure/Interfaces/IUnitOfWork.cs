using System;
using System.Collections.Generic;
using System.Text;

namespace DuongAppFirst.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Call Savechange from db context
        /// </summary>
        void Commit();
    }
}
