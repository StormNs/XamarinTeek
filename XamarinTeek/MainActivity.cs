using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;
using Android.Views;
using System.Net;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using Android.Support.V4.App;

namespace XamarinTeek
{
    [Activity(Label = "XamarinTeek", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
       
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource

            SetContentView(Resource.Layout.Main);

            string user = "Edme";
            string pass = "zaQ@123";
            string url = "http://10.0.2.2:63096/Account/Account/getAccountByUsernameAndPassword?username=" + user + "&password=" + pass + "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            HttpWebResponse myResp = (HttpWebResponse)request.GetResponse();
            Stream rebut = myResp.GetResponseStream();
            StreamReader readStream = new StreamReader(rebut, Encoding.UTF8); // Pipes the stream to a higher level stream reader with the required encoding format. 
            string info = readStream.ReadToEnd();
            var validate = JsonConvert.DeserializeObject<Boolean>(info);


            //Signup

            //string url = "http://10.0.2.2:63096/Account/Account/createAccount?username=<value>&password=<value>";
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //request.Method = "GET";
            //request.ContentType = "application/json";
            //HttpWebResponse myResp = (HttpWebResponse)request.GetResponse();
            //Stream rebut = myResp.GetResponseStream();
            //StreamReader readStream = new StreamReader(rebut, Encoding.UTF8); // Pipes the stream to a higher level stream reader with the required encoding format. 
            //string info = readStream.ReadToEnd();
            //var success = JsonConvert.DeserializeObject<Boolean>(info);


            Button btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            btnLogin.Click += delegate
            {
                //if(CheckLogIn())
                StartActivity(typeof(MainLayoutActivity));

            };

            Button btnSignIn = FindViewById<Button>(Resource.Id.btnSignUp);
            btnSignIn.Click += delegate
            {
                StartActivity(typeof(RegisterActivity));
            };

        }


        public override void OnBackPressed()
        {
            base.OnBackPressed();
        }


        public bool CheckLogIn()
        {
            bool validate = false;
            //Check account
            string user = FindViewById<EditText>(Resource.Id.edtUsername).Text;
            string pass = FindViewById<EditText>(Resource.Id.edtPassword).Text;
            if(user.Length > 0 && pass.Length > 0)
            {
                string url = "http://10.0.2.2:63096/Account/Account/getAccountByUsernameAndPassword?username=" + user + "&password=" + pass + "";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "application/json";
                HttpWebResponse myResp = (HttpWebResponse)request.GetResponse();
                Stream rebut = myResp.GetResponseStream();
                StreamReader readStream = new StreamReader(rebut, Encoding.UTF8); // Pipes the stream to a higher level stream reader with the required encoding format. 
                string info = readStream.ReadToEnd();
                validate = JsonConvert.DeserializeObject<Boolean>(info);
            }
            return validate;
        }

    }
}

