using MyLeagueManagementServer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeagueManagementServer.BUS
{
    public class PlayersBUS
    {
        public void post(ref string serial)
        {
            FirebaseDB firebaseDB = new FirebaseDB(CONSTANT.FIREBASE_URL);
            FirebaseDB firebaseDBTeams = firebaseDB.Node("Players");
            Console.WriteLine("POST Request");
            FirebaseResponse postResponse = firebaseDBTeams.Post(serial);
            Console.WriteLine(postResponse.Success);
            Console.WriteLine();
        }
        public string get(out string temp)
        {
            FirebaseDB firebaseDB = new FirebaseDB(CONSTANT.FIREBASE_URL);
            FirebaseDB firebaseDBTeams = firebaseDB.Node("Players");
            Console.WriteLine("GET Request");
            FirebaseResponse getResponse = firebaseDBTeams.Get();
            temp = getResponse.JSONContent;
            return temp;
        }
        public string getbykey(out string temp, string key)
        {
            FirebaseDB firebaseDB = new FirebaseDB(CONSTANT.FIREBASE_URL);
            FirebaseDB firebaseDBTeams = firebaseDB.Node("Players").Node(key);
            Console.WriteLine("GET Request");
            FirebaseResponse getResponse = firebaseDBTeams.Get();
            temp = getResponse.JSONContent;
            return temp;
        }
        public void patch()
        {
            FirebaseDB firebaseDB = new FirebaseDB(CONSTANT.FIREBASE_URL);
            FirebaseDB firebaseDBTeams = firebaseDB.Node("Clubs");
            FirebaseResponse patchResponse = firebaseDBTeams
                .Patch("{\"Designation\":\"CRM Consultant\"}");
        }
        public void delete(string Key)
        {
            FirebaseDB firebaseDB = new FirebaseDB(CONSTANT.FIREBASE_URL);
            FirebaseDB firebaseDBTeams = firebaseDB.Node("Clubs").Node(Key);
            FirebaseResponse deleteResponse = firebaseDBTeams.Delete();
        }
        public void put(ref string serial, string para)
        {

            FirebaseDB firebaseDB = new FirebaseDB(CONSTANT.FIREBASE_URL);
            FirebaseDB firebaseDBTeams = firebaseDB.NodePath("Players/" + para);
            FirebaseResponse putResponse = firebaseDBTeams.Put(serial);
        }
    }
}
