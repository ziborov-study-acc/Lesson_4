using FlowerService.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerService.Services.Repositories {
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class {
        protected FlowerServiceContext Context { get; set; }

        public RepositoryBase(FlowerServiceContext context) {
            Context = context;
        }
        public IEnumerable<T> All() {
            return Context.Set<T>();
        }

        public void Create(T item) {
            Context.Set<T>().Add(item);
        }

        public void Delete(T item) {
            Context.Set<T>().Remove(item);
        }

        public void Update(T item) {
            Context.Set<T>().Update(item);
        }

    }
}
