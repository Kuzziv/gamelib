using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.CharacterFactory.Services
{
    /// <summary>
    /// Interface for observing changes in a subject.
    /// </summary>
    public interface IObserver
    {
        /// <summary>
        /// Method called when the subject notifies the observer.
        /// </summary>
        void Update();
    }
}
