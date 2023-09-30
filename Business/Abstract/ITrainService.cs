using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITrainService
    {
        List<Train> GetAll(Expression<Func<Train, bool>> filter = null);
        Train Get(Expression<Func<Train, bool>> filter);
        void Add(Train entity);
        void Update(Train entity);
        void Delete(Train entity);
    }
}
