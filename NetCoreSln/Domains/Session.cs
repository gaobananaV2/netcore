using System;

namespace Domains
{
    public interface ISession
    {
        Single<Session> LogIn(string id,string pass);

        Completable LogOut();
    }

    public class Session : ISession
    {
        public Single<Session> LogIn(string id, string pass)
        {
            throw new NotImplementedException();
        }

        public Completable LogOut()
        {
            // Repository delete
            throw new NotImplementedException();
        }
    }

    public class Completable
    {
    }

    public class Single<T>
    {
    }


}
