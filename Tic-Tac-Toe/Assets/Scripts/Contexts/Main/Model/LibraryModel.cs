using System.Collections.Generic;
using System.Linq;

namespace Contexts.Main.Model
{
    public abstract class LibraryModel<TC> where TC : Config
    {
        protected List<TC> _libraryData = new List<TC>();

        public void Initialize(IEnumerable<TC> libraryData)
        {
            _libraryData = libraryData.ToList();
        }
    }
}