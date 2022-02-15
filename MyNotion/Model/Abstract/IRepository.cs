using System.Collections.Generic;

namespace MyNotion.Model.Abstract
{
    public interface IRepository
    {
        IEnumerable<Interest> Interests { get; }
        void SaveInterest(Interest interest);
        Interest? DeleteInterest(long interestsID);
    }
}
