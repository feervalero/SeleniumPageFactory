using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharedClasses;


namespace Whirlpool
{
    [TestClass]
    public class SKUSingleTest : WhirlpoolBaseTestClass
    {

        [TestMethod]
        public void CheckPLPs()
        {
            Assert.IsTrue(Whirlpool.Header.GetMenus());
        }

        [TestMethod]
        public void TestDate()
        {
            var a = DataBase.GetDateFormatDB();
            a = "";
        }


        [TestMethod]
        public void BuscarManuales()
        {
            IList<string> items = DataBase.GetPendingManuals();

            foreach (string item in items)
            {
                DataBase.AddItem(item);
                Whirlpool.Header.SearchItem(item);
                if (Whirlpool.SearchPage.hasResults(item))
                {
                    Whirlpool.SearchPage.GoToPDP();
                    if (Whirlpool.PDP.IsAt)
                    {
                        Whirlpool.PDP.getDocuments(item);
                        Whirlpool.PDP.getInfoFromPDP(item);
                    }
                    else
                    {
                        
                        //DataBase.AddManual(item, "PDP error", "PDP error", "0");
                        //DataBase.AddManual2(item, "PDP error", "PDP error", "0");
                    }
                }
                else
                {
                    //DataBase.AddManual(item,"no searchable","no searchable","0");
                }

                var a = item;
                a = "";
            }

            

        }
        /*
        [TestMethod]
        public void SearchAndValidate()
        {
            //string[] items = {
            //    "WRX735SDHV"
            //};

            IList<string> items = DataBase.GetProducts("WHR");

            foreach (string item in items)
            {
                
               Whirlpool.Header.SearchItem(item);

                if (Whirlpool.SearchPage.hasResults())
                {
                    Whirlpool.SearchPage.GoToPDP();
                    if (Whirlpool.PDP.IsAt)
                    {
                        Whirlpool.PDP.getInfoFromPDP(item);
                        Assert.IsTrue(true);
                    }
                    else
                    {
                        DataBase.InsertNotFoundItem(item,"WHR");
                    }
                    //Assert.IsTrue(Whirlpool.PDP.HasFeatures(), "Features not found");
                }
                else
                {
                    SharedClasses.DataBase.InsertNotFoundItem(item,"WHR");
                }

                
                
            }

            //CompareDataBase();
            

        }
        
        [TestMethod]
        public void CompareDataBase()
        {
            IList<ResultType> resultados = DataBase.Compare();

            if (resultados.Count > 0)
            {
                string body =
                    "<h3>WHR - Resultado de auditoria</h3><tr><th>SKU</th><th>VALUE</th><th>ANTES</th><th>DESPUES</th></tr>";
                foreach (ResultType resultado in resultados)
                {
                    body = body + "<tr><td>" + resultado.SKU + "</td><td>" + resultado.Value + "</td><td>" +
                           resultado.Antes + "</td><td>" + resultado.Despues + "</td></tr>";
                }

                
                if (SendMailWithResult(body))
                {
                    DataBase.TempToAll();


                    Assert.IsTrue(false,"Issues were found check your mail");
                } //TODO Guarda Sesion con diferencias despues de enviar mail.
                
            }
            else
            {
                DataBase.TempToAllOk();
                //TODO Guarda sesion tal cual con version estable como last version updated

            }
        }*/ //Aqui se guardo lo del mail

        [TestMethod]
        public bool SendMailWithResult(string body)
        {
            

            bool sendEmail = new Helper().SendEmail("fernando_valero_openservice@whirlpool.com","Whirlpool Result - "+DateTime.Now.ToString(), body);
            System.Diagnostics.Debug.WriteLine(sendEmail.ToString());

            return sendEmail;
        }


    }
}