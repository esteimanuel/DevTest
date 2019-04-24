using System.Collections.Generic;
using Refactoring.Models.Figures;

namespace Refactoring.Services.Figures
{
    public interface IFiguresStorage
    {
        void Add(Figure figure);
        IEnumerable<Figure> GetAll();
        void Reset();
    }
}
