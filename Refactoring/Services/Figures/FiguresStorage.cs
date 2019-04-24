using System.Collections.Generic;
using Refactoring.Models.Figures;

namespace Refactoring.Services.Figures
{
    public class FiguresStorage : IFiguresStorage
    {
        private readonly List<Figure> Figures = new List<Figure>();

        public void Add(Figure figure)
        {
            Figures.Add(figure);
        }

        public IEnumerable<Figure> GetAll()
        {
            return Figures.ToArray();
        }

        public void Reset()
        {
            Figures.Clear();
        }
    }
}