using Refactoring.Application.Models;
using Refactoring.Application.Interfaces.Repository;
using System.Collections.Generic;

namespace Refactoring.Repository.Memory
{
    public class ShapeRepository : IShapeRepository
    {
        private List<Shape> _shapes;

        public ShapeRepository()
        {
            _shapes = new List<Shape>();
        }

        public void Add(Shape shape)
        {
            _shapes.Add(shape);
        }

        public void Update(Shape shape)
        {
            // in case of memory repository implementation, update operation is redundant
        }

        public void Delete(Shape shape)
        {
            _shapes.Remove(shape);
        }
        
        public IEnumerable<Shape> GetAll()
        {
            return _shapes;
        }
    }
}