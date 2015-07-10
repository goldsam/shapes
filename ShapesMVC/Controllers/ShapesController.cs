using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShapesMVC.Models;
using System.Web.Http.Description;
using System.Threading.Tasks;
using ShapesMVC.Generator;

namespace ShapesMVC.Controllers
{
    /// <summary>
    /// Shapes API backend controller.
    /// </summary>
    public class ShapesController : ApiController
    {
        /// <summary>
        /// Database context.
        /// </summary>
        private IShapesContext _db = new ShapesContext();

        /// <summary>
        /// Constructs a controller using the default (deployment) database context.
        /// </summary>
        public ShapesController()
        {
            _db = new ShapesContext();
        }

        /// <summary>
        /// Constructs a controller using a given database context. This constructor is most useful for testing.
        /// </summary>
        /// <param name="db">Database context.</param>
        public ShapesController(IShapesContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Stores a set of shape parameters in the database, returning a generated shape with these parameters.
        /// </summary>
        /// <param name="shapeParameters"></param>
        /// <returns><see cref="IHttpActionResult"/> implementing action</returns>
        public IHttpActionResult PostShape([FromBody] ShapeParametersModel shapeParameters)
        {
            if(!ModelState.IsValid) {
                return BadRequest();
            }

            ShapeModel shape = GenerateShape(shapeParameters);

            _db.ShapeParameters.Add(shapeParameters);
            _db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = shapeParameters.Id }, shape);
        }

        /// <summary>
        /// Returns a page of shapes in the database.
        /// </summary>
        /// <param name="page">1-based page number</param>
        /// <param name="pageSize">Number of elements per page to return</param>
        /// <returns><see cref="IHttpActionResult"/> implementing action</returns>
        public IHttpActionResult GetShapes(int page=1, int pageSize =5)
        {
            return Ok(PagedCollection<ShapeModel>.ExtractAndConvert(
                _db.ShapeParameters.OrderByDescending(s => s.Id),
                page, pageSize,
                (x => GenerateShape(x))));
        }

        /// <summary>
        /// Returns a shape with a given identifier.
        /// </summary>
        /// <param name="id">Id of shape to return</param>
        /// <returns><see cref="IHttpActionResult"/> implementing action</returns>
        public IHttpActionResult GetShape(int id)
        {
            ShapeParametersModel shapeSpecification = 
                _db.ShapeParameters.FirstOrDefault((p) => p.Id == id);

            if (shapeSpecification == null) {
                return NotFound();
            }

            ShapeModel shape = GenerateShape(shapeSpecification);
            return Ok(shape);
        }

        /// <summary>
        /// Creates a complete <see cref="ShapeModel"/> from a given <see cref="ShapeParametersModel"/>
        /// instance. This involves rendering the shape specified by the parameters.
        /// </summary>
        /// <param name="shapeParameters">Shape parameters</param>
        /// <returns>Generated shape</returns>
        private ShapeModel GenerateShape(ShapeParametersModel shapeParameters)
        {
            ShapeGenerator shapeGenerator =
                ShapeGeneratorFactory.GetShapeGenerator(shapeParameters.Type);
            String renderedShape = shapeGenerator.GetShapeString(shapeParameters);
            ShapeModel shape = new ShapeModel {
                Parameters = shapeParameters,
                RenderedShape = renderedShape
            };

            return shape;
        }

        /// <summary>
        /// Ensure the database resource is properly released w
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                _db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
