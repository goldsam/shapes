using System.Data.Entity;

namespace ShapesMVC.Models
{
    public class ShapesContext : DbContext, IShapesContext
    {
        public ShapesContext()
            : base("name=DefaultConnection")
        {
        }

        public void MarkAsModified(ShapeParametersModel shapeSpecification)
        {
            Entry(shapeSpecification).State = EntityState.Modified;
        }

        public DbSet<ShapeParametersModel> ShapeParameters { get; set; }
    }
}