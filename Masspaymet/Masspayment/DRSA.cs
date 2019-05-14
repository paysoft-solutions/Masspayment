using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;
using System.Security.Cryptography;
using System.IO;

namespace Masspayment
{
    public class DRSA
    {
        public int errno;
        public string errstr = "";
        public RSACryptoServiceProvider RSAPrivateKey;

        public DRSA()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");               
        }

        public bool InitPrivateKey(string PrivateKey)
        {
            if (PrivateKey.Length == 0)
            {
                return false;
            }

            byte[] byteKey = DecodeOpenSSLPrivateKey(PrivateKey);
            if (byteKey == null)
            {
                return false;
            }

            RSAPrivateKey = DecodeRSAPrivateKey(byteKey);
            if (RSAPrivateKey == null)
            {
                return false;
            }

            return true;
        }

        public byte[] SignData(byte[] data, HashAlgorithm alg)
        {
            byte[] sign = null;

            try
            {
                sign = RSAPrivateKey.SignData(data, alg);
            }
            catch
            {
                return null;
            }

            return sign;
        }

        private byte[] DecodeOpenSSLPrivateKey(String instr)
        {
            const String pemprivheader = "-----BEGIN RSA PRIVATE KEY-----";
            const String pemprivfooter = "-----END RSA PRIVATE KEY-----";
            String pemstr = instr.Trim();
            byte[] binkey;
            if (!pemstr.StartsWith(pemprivheader) || !pemstr.EndsWith(pemprivfooter))
                return null;

            var sb = new StringBuilder(pemstr);
            sb.Replace(pemprivheader, ""); 
            sb.Replace(pemprivfooter, "");

            String pvkstr = sb.ToString().Trim(); 

            try
            {
                binkey = Convert.FromBase64String(pvkstr);
                return binkey;
            }
            catch (FormatException)
            {
                return null;
            }
        }

        private RSACryptoServiceProvider DecodeRSAPrivateKey(byte[] privkey)
        {
            byte[] MODULUS, E, D, P, Q, DP, DQ, IQ;
            
            var mem = new MemoryStream(privkey);
            var binr = new BinaryReader(mem); 
            byte bt = 0;
            ushort twobytes = 0;
            int elems = 0;

            try
            {
                twobytes = binr.ReadUInt16();
                if (twobytes == 0x8130) 
                    binr.ReadByte(); 
                else if (twobytes == 0x8230)
                    binr.ReadInt16(); 
                else
                    return null;

                twobytes = binr.ReadUInt16();
                if (twobytes != 0x0102) 
                    return null;
                bt = binr.ReadByte();
                if (bt != 0x00)
                    return null;
                
                elems = GetIntegerSize(binr);
                MODULUS = binr.ReadBytes(elems);
                elems = GetIntegerSize(binr);
                E = binr.ReadBytes(elems);
                elems = GetIntegerSize(binr);
                D = binr.ReadBytes(elems);
                elems = GetIntegerSize(binr);
                P = binr.ReadBytes(elems);
                elems = GetIntegerSize(binr);
                Q = binr.ReadBytes(elems);
                elems = GetIntegerSize(binr);
                DP = binr.ReadBytes(elems);
                elems = GetIntegerSize(binr);
                DQ = binr.ReadBytes(elems);
                elems = GetIntegerSize(binr);
                IQ = binr.ReadBytes(elems);

                CspParameters _cpsParameter = new CspParameters();
                _cpsParameter.Flags = CspProviderFlags.UseMachineKeyStore;

                var RSA = new RSACryptoServiceProvider(_cpsParameter);

                var RSAparams = new RSAParameters();

                RSAparams.Modulus = MODULUS;
                RSAparams.Exponent = E;
                RSAparams.D = D;
                RSAparams.P = P;
                RSAparams.Q = Q;
                RSAparams.DP = DP;
                RSAparams.DQ = DQ;
                RSAparams.InverseQ = IQ;

                RSA.ImportParameters(RSAparams);

                return RSA;
            }
            catch 
            {
                return null;
            }
            finally
            {
                binr.Close();
            }
        }

        private int GetIntegerSize(BinaryReader binr)
        {
            byte bt = 0;
            byte lowbyte = 0x00;
            byte highbyte = 0x00;
            int count = 0;
            bt = binr.ReadByte();
            if (bt != 0x02) 
                return 0;
            bt = binr.ReadByte();

            if (bt == 0x81)
            {
                count = binr.ReadByte();
            }
            else
            {
                if (bt == 0x82)
                {
                    highbyte = binr.ReadByte();
                    lowbyte = binr.ReadByte();
                    byte[] modint = { lowbyte, highbyte, 0x00, 0x00 };
                    count = BitConverter.ToInt32(modint, 0);
                }
                else
                {
                    count = bt; 
                }
            }

            while (binr.ReadByte() == 0x00)
            {
                count -= 1;
            }

            binr.BaseStream.Position = binr.BaseStream.Position - 1;
            
            return count;
        }
    }
}

