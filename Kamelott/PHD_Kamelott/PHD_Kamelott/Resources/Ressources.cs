using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace PHD_Kamelott.Resources
{
    class Ressources
    {
        public static Stream GetSampleStreamFromRessources(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            Stream retour = null;
            try
            {
                retour = assembly.GetManifestResourceStream("PHD_Kamelott.Resources.Samples."+filename);

            }
            catch (Exception ex) { }
            return retour;
        }






        public static string GetJSONFromRessources(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            string retour = "";

            try
            {
                var stream = assembly.GetManifestResourceStream("PHD_Kamelott.Resources." + filename);
                
                using(StreamReader sr = new StreamReader(stream))
                {
                    while (!sr.EndOfStream)
                    {
                        retour += sr.ReadLine();
                    }
                 
                }
                stream.Close();
            }
            catch
            {

            }
            return retour;
        }
    }
}
