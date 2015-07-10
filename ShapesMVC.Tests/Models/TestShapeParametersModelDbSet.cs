using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapesMVC.Models;

namespace ShapesMVC.Tests.Models
{
    class TestShapeParametersModelDbSet : TestDbSet<ShapeParametersModel>
    {
        public override ShapeParametersModel Find(params object[] keyValues)
        {
            return this.SingleOrDefault(s => s.Id == (int)keyValues.Single());
        }
    }
}
