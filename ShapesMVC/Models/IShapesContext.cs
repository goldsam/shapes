using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesMVC.Models
{
    public interface IShapesContext : IDisposable
    {
        DbSet<ShapeParametersModel> ShapeParameters { get; }
        
        int SaveChanges();

        void MarkAsModified(ShapeParametersModel item);
    }
}
