using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeagueManagementServer.DAL
{
    public class ConnectDatabase
    {
        public void ConnectFirebase()
        {
            FirebaseDB firebaseDB = new FirebaseDB(CONSTANT.FIREBASE_URL);
            FirebaseDB firebaseDBUser = firebaseDB.Node("User");
        }
    }
}
