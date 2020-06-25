using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeagueManagementServer.DAL
{
    public class CONSTANT
    {
        public const string JSON_SUFFIX = ".json";
        public const string USER_AGENT = "firebase-net/1.0";
        public const string FIREBASE_DOMAIN = "firebaseio.com";
        public const string RESPONSE_FAIL = "Proided Firebase path is not a valid HTTP/S URL";
        public const string FORMAT_EXCEPTION = "Node must not contain '/', use NodePath instead.";
        public const string FIREBASE_URL = "https://myleaguemanagement.firebaseio.com";
    }
}
