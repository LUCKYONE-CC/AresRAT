using System.Security.Cryptography;


namespace Client.Communication.Encryption
{
    public static class RSA
    {
        public static string[] GenerateKeys()
        {
            //lets take a new CSP with a new 2048 bit rsa key pair
            var csp = new RSACryptoServiceProvider(2048);

            //how to get the private key
            RSAParameters privKey = csp.ExportParameters(true);

            //and the public key ...
            RSAParameters pubKey = csp.ExportParameters(false);

            //converting the private key into a string representation
            string privKeyString = ConvertRSAKeyToString(privKey);

            //converting the public key into a string representation
            string pubKeyString = ConvertRSAKeyToString(pubKey);

            return new string[] { pubKeyString, privKeyString };
        }
        public static string Decrypt(RSAParameters privKey, string cypherText)
        {
            //first, get our bytes back from the base64 string ...
            byte[] bytesCypherText = Convert.FromBase64String(cypherText);

            //we want to decrypt, therefore we need a csp and load our private key
            var csp = new RSACryptoServiceProvider();
            csp.ImportParameters(privKey);

            //decrypt and strip pkcs#1.5 padding
            byte[] bytesPlainTextData = csp.Decrypt(bytesCypherText, false);

            //get our original plainText back...
            string plainTextData = System.Text.Encoding.Unicode.GetString(bytesPlainTextData);
            return plainTextData;
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
