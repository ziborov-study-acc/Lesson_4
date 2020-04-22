using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerService.Services.Interfaces {
    public interface IRepositoryBase<T> where T : class {
        IEnumerable<T> All();
        void Create(T item);
        void Update(T item);
        void Delete(T item);

    }
}
