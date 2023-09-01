using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Server.Communication.Encryption
{
    public static class RSA
    {
        public static string Encrypt(RSAParameters rsaPubKey, string plainTextData)
        {
            //we have a public key ... let's get a new csp and load that key
            var csp = new RSACryptoServiceProvider();
            csp.ImportParameters(rsaPubKey);

            //for encryption, always handle bytes...
            var bytesPlainTextData = System.Text.Encoding.Unicode.GetBytes(plainTextData);

            //apply pkcs#1.5 padding and encrypt our data 
            var bytesCypherText = csp.Encrypt(bytesPlainTextData, false);

            //we might want a string representation of our cypher text... base64 will do
            var cypherText = Convert.ToBase64String(bytesCypherText);

            return cypherText;
        }

        public static RSAParameters ConvertRSAKeyToRSAParameters(string rsaKeyString)
        {
            //converting rsaPubKeyString back to RSAParameter

            //get a stream from the string
            var sr = new System.IO.StringReader(rsaKeyString);
            //we need a deserializer
            var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
            //get the object back from the stream
            RSAParameters rsaKey = (RSAParameters)xs.Deserialize(sr);
            return rsaKey;
        }
        public static string ConvertRSAKeyToString(RSAParameters rsaKey)
        {
            //we need some buffer
            var sw = new System.IO.StringWriter();
            //we need a serializer
            var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
            //serialize the key into the stream
            xs.Serialize(sw, rsaKey);
            //get the string from the stream
            string pubKeyString = sw.ToString();
            return pubKeyString;
        }
    }
}
