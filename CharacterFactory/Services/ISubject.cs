using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.CharacterFactory.Services
{
    /// <summary>
    /// Interface for subjects that can be observed by observers.
    /// </summary>
    public interface ISubject
    {
        /// <summary>
        /// Attaches an observer to the subject.
        /// </summary>
        /// <param name="observer">The observer to attach.</param>
        void Attach(IObserver observer);

        /// <summary>
        /// Detaches an observer from the subject.
        /// </summary>
        /// <param name="observer">The observer to detach.</param>
        void Detach(IObserver observer);

        /// <summary>
        /// Notifies all observers attached to the subject.
        /// </summary>
        void Notify();
    }
}
