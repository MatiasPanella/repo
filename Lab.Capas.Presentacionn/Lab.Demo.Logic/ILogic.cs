using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Demo.Logic
{
    interface ILogic<T>
    {
        List<T> GetAll();

        T GetOne(int id);

        T Insert(T entity);

        void Update(T entity);

        void Delete(int id);

    }
}
