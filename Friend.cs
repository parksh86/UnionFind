using System;
using System.Collections.Generic;
using System.Linq;

namespace Friend
{
    public class Friend
    {
        public static int friendInstanceCount = 0;
        public static int[] friendArrayment;

        public int Sequence { get; private set; }
        public string Email { get; private set; }
        public ICollection<Friend> Friends { get; private set; }
        public Friend(string email)
        {
            friendInstanceCount++;

            this.Sequence = friendInstanceCount;
            this.Email = email;
            this.Friends = new List<Friend>();
        }
        public void AddFriendship(Friend friend)
        {
            this.Friends.Add(friend);
            friend.Friends.Add(this);

            Union(this.Sequence, friend.Sequence);
        }

        public void Union(int mySequence, int friendSequence)
        {
            mySequence = Find(mySequence);
            friendSequence = Find(friendSequence);

            if (mySequence != friendSequence)
            {
                if (mySequence < friendSequence)
                    friendArrayment[friendSequence] = mySequence;
                else
                    friendArrayment[mySequence] = friendSequence;
            }
        }

        public int Find(int sequence)
        {
            if (sequence == friendArrayment[sequence])
                return sequence;
            else
                return friendArrayment[sequence] = Find(friendArrayment[sequence]);
        }

        public bool CanBeConnected(Friend friend)
        {
            int mySequence = Find(this.Sequence);
            int targetSequence = Find(friend.Sequence);

            if (mySequence == targetSequence)
                return true;
            else
                return false;
        }

        public static void Main(string[] args)
        {
            Friend a = new Friend("A");
            Friend b = new Friend("B");
            Friend c = new Friend("C");

            Friend d = new Friend("D");
            Friend e = new Friend("E");
            Friend f = new Friend("F");
            Friend g = new Friend("G");

            friendArrayment = new int[friendInstanceCount + 1];

            for (int i = 1; i <= friendInstanceCount; i++)
            {
                friendArrayment[i] = i;
            }

            a.AddFriendship(b);
            b.AddFriendship(c);

            d.AddFriendship(e);
            a.AddFriendship(f);
            g.AddFriendship(c);

            Console.WriteLine(a.CanBeConnected(c));
            Console.WriteLine(a.CanBeConnected(b));
            Console.WriteLine(a.CanBeConnected(d));
        }
    }
}
