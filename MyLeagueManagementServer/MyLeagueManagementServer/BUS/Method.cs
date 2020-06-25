﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyLeagueManagementServer.DAL;

namespace MyLeagueManagementServer.BUS
{
    public class Method
    {
        public void post(ref string serial)
        {

            FirebaseDB firebaseDB = new FirebaseDB(CONSTANT.FIREBASE_URL);
            FirebaseDB firebaseDBTeams = firebaseDB.Node("User");
            Console.WriteLine("POST Request");
            FirebaseResponse postResponse = firebaseDBTeams.Post(serial);
            Console.WriteLine(postResponse.Success);
            Console.WriteLine();
        }
        public string get(out string temp)
        {
            FirebaseDB firebaseDB = new FirebaseDB(CONSTANT.FIREBASE_URL);
            FirebaseDB firebaseDBTeams = firebaseDB.Node("User");
            Console.WriteLine("GET Request");
            FirebaseResponse getResponse = firebaseDBTeams.Get();
            Console.WriteLine(getResponse.Success);
            if (getResponse.Success)
                Console.WriteLine(getResponse.JSONContent);
            Console.WriteLine();
            temp = getResponse.JSONContent;
            return temp;
        }
        public void patch()
        {
            FirebaseDB firebaseDB = new FirebaseDB(CONSTANT.FIREBASE_URL);
            FirebaseDB firebaseDBTeams = firebaseDB.Node("User");
            Console.WriteLine("PATCH Request");
            FirebaseResponse patchResponse = firebaseDBTeams
                .Patch("{\"Designation\":\"CRM Consultant\"}");
            Console.WriteLine(patchResponse.Success);
            Console.WriteLine();
        }
        public void delete()
        {
            FirebaseDB firebaseDB = new FirebaseDB(CONSTANT.FIREBASE_URL);
            FirebaseDB firebaseDBTeams = firebaseDB.Node("User");
            Console.WriteLine("DELETE Request");
            FirebaseResponse deleteResponse = firebaseDBTeams.Delete();
            Console.WriteLine(deleteResponse.Success);
            Console.WriteLine();

            Console.WriteLine(firebaseDBTeams.ToString());
            Console.ReadLine();
        }
        public void put(ref string serial)
        {

            FirebaseDB firebaseDB = new FirebaseDB(CONSTANT.FIREBASE_URL);
            FirebaseDB firebaseDBTeams = firebaseDB.Node("User");
            Console.WriteLine("PUT Request");
            FirebaseResponse putResponse = firebaseDBTeams.Put(serial);
            Console.WriteLine(putResponse.Success);
            Console.WriteLine();
        }
    }
}