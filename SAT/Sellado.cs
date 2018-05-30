using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SAT
{
    public class Sellado
    {
        public static RSACryptoServiceProvider
            DecodePrivateKeyInfo(byte[] encpkcs8, string pPassword)
        {
            // encoded OID sequence for  PKCS #1 rsaEncryption szOID_RSA_RSA = "1.2.840.113549.1.1.1"
            // this byte[] includes the sequence byte and terminal encoded null
            byte[] oiDpkcs5Pbes2 = { 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x05, 0x0D };
            byte[] oiDpkcs5Pbkdf2 = { 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x05, 0x0C };
            byte[] oiDdesEde3Cbc = { 0x06, 0x08, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x03, 0x07 };

            // ---------  Set up stream to read the asn.1 encoded SubjectPublicKeyInfo blob  ------
            var mem = new MemoryStream(encpkcs8);
            var binr = new BinaryReader(mem); //wrap Memory Stream with BinaryReader for easy reading

            try
            {
                var twobytes = binr.ReadUInt16();
                switch (twobytes)
                {
                    case 0x8130:
                        //data read as little endian order (actual data order for Sequence is 30 81)
                        binr.ReadByte(); //advance 1 byte
                        break;
                    case 0x8230:
                        binr.ReadInt16(); //advance 2 bytes
                        break;
                    default:
                        return null;
                        /*
                                                    break;
                            */
                }

                twobytes = binr.ReadUInt16(); //inner sequence
                switch (twobytes)
                {
                    case 0x8130:
                        binr.ReadByte();
                        break;
                    case 0x8230:
                        binr.ReadInt16();
                        break;
                }

                var seq = binr.ReadBytes(11);
                if (!CompareBytearrays(seq, oiDpkcs5Pbes2)) //is it a OIDpkcs5PBES2 ?
                {
                    return null;
                }

                twobytes = binr.ReadUInt16(); //inner sequence for pswd salt
                switch (twobytes)
                {
                    case 0x8130:
                        binr.ReadByte();
                        break;
                    case 0x8230:
                        binr.ReadInt16();
                        break;
                }

                twobytes = binr.ReadUInt16(); //inner sequence for pswd salt
                switch (twobytes)
                {
                    case 0x8130:
                        binr.ReadByte();
                        break;
                    case 0x8230:
                        binr.ReadInt16();
                        break;
                }

                seq = binr.ReadBytes(11); //read the Sequence OID
                if (!CompareBytearrays(seq, oiDpkcs5Pbkdf2)) //is it a OIDpkcs5PBKDF2 ?
                {
                    return null;
                }

                twobytes = binr.ReadUInt16();
                switch (twobytes)
                {
                    case 0x8130:
                        binr.ReadByte();
                        break;
                    case 0x8230:
                        binr.ReadInt16();
                        break;
                }

                var bt = binr.ReadByte();
                if (bt != 0x04) //expect octet string for salt
                {
                    return null;
                }
                int saltsize = binr.ReadByte();
                var salt = binr.ReadBytes(saltsize);

                bt = binr.ReadByte();
                if (bt != 0x02) //expect an integer for PBKF2 interation count
                {
                    return null;
                }

                int itbytes = binr.ReadByte(); //PBKD2 iterations should fit in 2 bytes.
                int iterations;
                if (itbytes == 1)
                {
                    iterations = binr.ReadByte();
                }
                else if (itbytes == 2)
                {
                    iterations = 256 * binr.ReadByte() + binr.ReadByte();
                }
                else
                {
                    return null;
                }

                twobytes = binr.ReadUInt16();
                if (twobytes == 0x8130)
                {
                    binr.ReadByte();
                }
                else if (twobytes == 0x8230)
                {
                    binr.ReadInt16();
                }

                var seqdes = binr.ReadBytes(10);
                if (!CompareBytearrays(seqdes, oiDdesEde3Cbc)) //is it a OIDdes-EDE3-CBC ?
                {
                    return null;
                }

                bt = binr.ReadByte();
                if (bt != 0x04) //expect octet string for IV
                {
                    return null;
                }
                int ivsize = binr.ReadByte();
                var iv = binr.ReadBytes(ivsize);

                bt = binr.ReadByte();
                if (bt != 0x04) // expect octet string for encrypted PKCS8 data
                {
                    return null;
                }

                bt = binr.ReadByte();

                int encblobsize;
                if (bt == 0x81)
                {
                    encblobsize = binr.ReadByte(); // data size in next byte
                }
                else if (bt == 0x82)
                {
                    encblobsize = 256 * binr.ReadByte() + binr.ReadByte();
                }
                else
                {
                    encblobsize = bt; // we already have the data size
                }

                var encryptedpkcs8 = binr.ReadBytes(encblobsize);
                var secpswd = new SecureString();
                foreach (var c in pPassword)
                {
                    secpswd.AppendChar(c);
                }

                var pkcs8 = DecryptPbdk2(encryptedpkcs8, salt, iv, secpswd, iterations);
                if (pkcs8 == null) // probably a bad pswd entered.
                {
                    return null;
                }

                var rsa = DecodePrivateKeyInfo(pkcs8);
                return rsa;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                binr.Close();
            }
        }

        public static RSACryptoServiceProvider DecodePrivateKeyInfo(byte[] pkcs8)
        {
            // encoded OID sequence for  PKCS #1 rsaEncryption szOID_RSA_RSA = "1.2.840.113549.1.1.1"
            // this byte[] includes the sequence byte and terminal encoded null
            byte[] seqOid = { 0x30, 0x0D, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x01, 0x01, 0x05, 0x00 };
            // ---------  Set up stream to read the asn.1 encoded SubjectPublicKeyInfo blob  ------
            var mem = new MemoryStream(pkcs8);
            var lenstream = (int)mem.Length;
            var binr = new BinaryReader(mem); //wrap Memory Stream with BinaryReader for easy reading

            try
            {
                var twobytes = binr.ReadUInt16();
                if (twobytes == 0x8130) //data read as little endian order (actual data order for Sequence is 30 81)
                {
                    binr.ReadByte(); //advance 1 byte
                }
                else if (twobytes == 0x8230)
                {
                    binr.ReadInt16(); //advance 2 bytes
                }
                else
                {
                    return null;
                }

                var bt = binr.ReadByte();
                if (bt != 0x02)
                {
                    return null;
                }

                twobytes = binr.ReadUInt16();

                if (twobytes != 0x0001)
                {
                    return null;
                }

                var seq = binr.ReadBytes(15);
                if (!CompareBytearrays(seq, seqOid)) //make sure Sequence for OID is correct
                {
                    return null;
                }

                bt = binr.ReadByte();
                if (bt != 0x04) //expect an Octet string
                {
                    return null;
                }

                bt = binr.ReadByte(); //read next byte, or next 2 bytes is  0x81 or 0x82; otherwise bt is the byte count
                if (bt == 0x81)
                {
                    binr.ReadByte();
                }
                else if (bt == 0x82)
                {
                    binr.ReadUInt16();
                }
                //------ at this stage, the remaining sequence should be the RSA private key

                var rsaprivkey = binr.ReadBytes((int)(lenstream - mem.Position));
                var rsacsp = DecodeRsaPrivateKey(rsaprivkey);
                return rsacsp;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                binr.Close();
            }
        }

        public static RSACryptoServiceProvider DecodeRsaPrivateKey(byte[] privkey)
        {
            // ---------  Set up stream to decode the asn.1 encoded RSA private key  ------
            var mem = new MemoryStream(privkey);
            var binr = new BinaryReader(mem); //wrap Memory Stream with BinaryReader for easy reading
            try
            {
                var twobytes = binr.ReadUInt16();
                if (twobytes == 0x8130) //data read as little endian order (actual data order for Sequence is 30 81)
                {
                    binr.ReadByte(); //advance 1 byte
                }
                else if (twobytes == 0x8230)
                {
                    binr.ReadInt16(); //advance 2 bytes
                }
                else
                {
                    return null;
                }

                twobytes = binr.ReadUInt16();
                if (twobytes != 0x0102) //version number
                {
                    return null;
                }
                var bt = binr.ReadByte();
                if (bt != 0x00)
                {
                    return null;
                }

                //------  all private key components are Integer sequences ----
                var elems = GetIntegerSize(binr);
                var modulus = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                var e = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                var d = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                var p = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                var q = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                var dp = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                var dq = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                var iq = binr.ReadBytes(elems);

                Console.WriteLine("showing components ..");

                // ------- create RSACryptoServiceProvider instance and initialize with public key -----
                var rsa = new RSACryptoServiceProvider();
                var rsAparams = new RSAParameters
                {
                    Modulus = modulus,
                    Exponent = e,
                    D = d,
                    P = p,
                    Q = q,
                    DP = dp,
                    DQ = dq,
                    InverseQ = iq
                };
                rsa.ImportParameters(rsAparams);
                return rsa;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                binr.Close();
            }
        }

        public static byte[] DecryptPbdk2(byte[] edata, byte[] salt,
            byte[] iv, SecureString secpswd, int iterations)
        {
            var psbytes = new byte[secpswd.Length];
            var unmanagedPswd = Marshal.SecureStringToGlobalAllocAnsi(secpswd);
            Marshal.Copy(unmanagedPswd, psbytes, 0, psbytes.Length);
            Marshal.ZeroFreeGlobalAllocAnsi(unmanagedPswd);

            try
            {
                var kd = new Rfc2898DeriveBytes(psbytes, salt, iterations);
                var decAlg = TripleDES.Create();
                decAlg.Key = kd.GetBytes(24);
                decAlg.IV = iv;
                var memstr = new MemoryStream();
                var decrypt = new CryptoStream(memstr, decAlg.CreateDecryptor(), CryptoStreamMode.Write);
                decrypt.Write(edata, 0, edata.Length);
                decrypt.Flush();
                decrypt.Close(); // this is REQUIRED.
                var cleartext = memstr.ToArray();
                return cleartext;
            }
            catch (Exception e)
            {
                Console.WriteLine("Problem decrypting: {0}", e.Message);
                return null;
            }
        }

        public void CertificateData(string pCerFile, out string certificate, out string certificateNumber)
        {
            var cert = new X509Certificate(pCerFile);
            var strcert = cert.GetRawCertData();
            certificate = Convert.ToBase64String(strcert);

            strcert = cert.GetSerialNumber();
            certificateNumber = Reverse(Encoding.UTF8.GetString(strcert));
        }

        public RSACryptoServiceProvider OpenKeyFile(string filename, string pPassword)
        {
            var keyblob = GetFileBytes(filename);
            if (keyblob == null)
            {
                return null;
            }

            var rsa = DecodePrivateKeyInfo(keyblob, pPassword);
            if (rsa != null)
            {
                return rsa;
            }
            return null;
        }

        public string Reverse(string original)
        {
            var reverse = "";
            for (var i = original.Length - 1; i >= 0; i--)
            {
                reverse += original.Substring(i, 1);
            }
            return reverse;
        }

        public string SignString(string pKeyFile, string pPassword, string originalString)
        {
            var signedString = "";
            var filename = pKeyFile;
            if (!File.Exists(filename))
            {
                return ".key file does not exist " + pKeyFile;
            }

            var rsa = OpenKeyFile(filename, pPassword);
            if (rsa != null)
            {
                var co = Encoding.UTF8.GetBytes(originalString);
                var signedBytes = rsa.SignData(co, new SHA1CryptoServiceProvider());
                signedString = Convert.ToBase64String(signedBytes);
            }
            return signedString;
        }

        private static bool CompareBytearrays(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
            {
                return false;
            }
            var i = 0;
            foreach (var c in a)
            {
                if (c != b[i])
                {
                    return false;
                }
                i++;
            }
            return true;
        }

        private static byte[] GetFileBytes(string filename)
        {
            if (!File.Exists(filename))
            {
                return null;
            }
            Stream stream = new FileStream(filename, FileMode.Open);
            var datalen = (int)stream.Length;
            var filebytes = new byte[datalen];
            stream.Seek(0, SeekOrigin.Begin);
            stream.Read(filebytes, 0, datalen);
            stream.Close();
            return filebytes;
        }

        private static int GetIntegerSize(BinaryReader binr)
        {
            int count;
            var bt = binr.ReadByte();
            if (bt != 0x02) //expect integer
            {
                return 0;
            }
            bt = binr.ReadByte();

            if (bt == 0x81)
            {
                count = binr.ReadByte(); // data size in next byte
            }
            else if (bt == 0x82)
            {
                var highbyte = binr.ReadByte();
                var lowbyte = binr.ReadByte();
                byte[] modint = { lowbyte, highbyte, 0x00, 0x00 };
                count = BitConverter.ToInt32(modint, 0);
            }
            else
            {
                count = bt; // we already have the data size
            }
            while (binr.ReadByte() == 0x00)
            {
                //remove high order zeros in data
                count -= 1;
            }
            binr.BaseStream.Seek(-1, SeekOrigin.Current);
            //last ReadByte wasn't a removed zero, so back up a byte
            return count;
        }
    }
}