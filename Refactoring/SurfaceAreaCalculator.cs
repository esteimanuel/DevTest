// Copyright © 2017 by Alexander Streng
// All rights reserved. 
// 
// SurfaceAreaCalculator.cs 
// 20 / 08 / 2017

using System.Collections.Generic;
using System.Linq;
using Refactoring.Logging;
using Refactoring.Shapes;

namespace Refactoring
{
    public class SurfaceAreaCalculator
    {
        private readonly List<IShape> _createdShapes;
        private readonly ILogger _logger;

        public SurfaceAreaCalculator(ILogger logger)
        {
            _logger = logger;
            _createdShapes = new List<IShape>();
        }

        public double[] ArrSurfaceAreas => _createdShapes.Select(shape => shape.SurfaceArea).ToArray();

        public void Add(IShape shapeObject)
        {
            _createdShapes.Add(shapeObject);
        }

        public void CalculateSurfaceAreas()
        {
            if (_createdShapes == null || !_createdShapes.Any())
            {
                _logger.Log("arrItems is null or empty!!");
                return;
            }
            _createdShapes.ForEach(shape => shape.CalculateSurfaceArea());
        }

        public void LogSurfaceAreas()
        {
            if (_createdShapes == null || !_createdShapes.Any())
            {
                _logger.Log("There are no surface areas to print!!");
                return;
            }
            _createdShapes.ForEach(shape => _logger.Log($"[{_createdShapes.IndexOf(shape)}]{shape}"));
        }

        public void ResetSurfaceAreas()
        {
            if (_createdShapes == null || !_createdShapes.Any())
            {
                _logger.Log("There are no surface areas to clear!!");
                return;
            }

            _createdShapes.Clear();
            _logger.Log("Reset state!!");
        }
    }
}