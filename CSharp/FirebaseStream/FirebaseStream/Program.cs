using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database.Query;
using System.Reactive.Linq;
using System.Threading;

namespace FirebaseStream
{
    class Program
    {
        static void Main(string[] args)
        {
            var auth = "Sx8dMHGYsTKxGohDaYV2KjV9BuvlZdl5QSmY4jWV"; // your app secret
            var firebaseClient = new FirebaseClient(
              "https://rfidtest-931fa.firebaseio.com/",
              new FirebaseOptions
              {
                  AuthTokenAsyncFactory = () => Task.FromResult(auth)
              });

            var firebase = new FirebaseClient("https://rfidtest-931fa.firebaseio.com/");
            var observable = firebase
              .Child("Information").AsObservable<Message>()
              .Subscribe(d => {
                  Console.WriteLine(d.Key);
              });
            Console.ReadLine();
        }
    }
}
