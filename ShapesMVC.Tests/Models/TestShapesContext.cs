using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapesMVC.Models;
using System.Data.Entity;

namespace ShapesMVC.Tests.Models
{
    public class TestShapesContext : IShapesContext
    {
        public TestShapesContext()
        {
            this.ShapeParameters = new TestShapeParametersModelDbSet();
        }

        public DbSet<ShapeParametersModel> ShapeParameters { get; private set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(ShapeParametersModel item) { }
        public void Dispose() { }
    }
}
