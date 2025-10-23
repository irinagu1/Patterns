using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPatterns
{
    public interface ProfileIterator
    {
        Profile getNext();
        bool hasNext();
    }
    public class FacebookIterator : ProfileIterator
    {
        public Facebook Facebook {  get; set; }
        public string profileId {  get; set; }

        public FacebookIterator() { }

        public Profile getNext()
        {
            throw new NotImplementedException();
        }

        public bool hasNext()
        {
            throw new NotImplementedException();
        }
    }

    public interface SocialNetwork
    {
        ProfileIterator createFriendsIterator(int profileId);
        ProfileIterator createCoworkersIterator(int profileId);
    }

    public class Facebook : SocialNetwork
    {
        public ProfileIterator createCoworkersIterator(int profileId)
        {
            throw new NotImplementedException();
        }

        public ProfileIterator createFriendsIterator(int profileId)
        {
            throw new NotImplementedException();
        }
    }

    public class Profile { }
}
