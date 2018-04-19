using System;

namespace WorkoutTracker.Exceptions
{
    public class EntityExistsException : Exception
    {
        public EntityExistsException(string message) : base(message) { }
    }
}
