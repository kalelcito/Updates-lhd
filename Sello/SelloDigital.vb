Imports CryptoSysPKI
Imports System.IO
Imports System.Text
Imports System.Windows.Forms
''' <summary>
''' *******************************************************************
''' ************       Transportación México Express       ************
''' ************          Sistema Local Infactmex          ************
''' *******************************************************************
''' ************ ---   DR México Express S.A. de C.V   --- ************
''' *******************************************************************
''' *******************************************************************
''' ************         Nombre: selloDigital.vb           ************
''' ************            Tipo: Lireria                  ************
''' *******************************************************************
''' 
''' Clase que procesa la cadena original para crear su Sello Digital
''' 1- Obtiene la cadena original
''' 2- Se encripta con el Certificado Digital
''' 3- Genera su Hash (MD5 o SHA1 o SHA254)
''' 4- crea el Sello Digital
''' 
''' </summary>
Public Class SelloDigital
    Public strcadBase64 As String
    Sub New()

        'strCadenaOriginal = "||2.0|A|402|2010-12-14T12:24:37|198165|2010|ingreso|PAGO EN UNA SOLA EXHIBICION|NETO A 30 DIAS FECHA FACTURA|12000.00|6600.00|6264.00|MET5306306ZA|TEST5|CUAUHTEMOC|205|ARAGON|DEL. GUSTAVO A. MADERO|DISTRITO FEDERAL|MEXICO|07000|CUAUHTEMOC|205|ARAGON|DEL. GUSTAVO A. MADERO|DISTRITO FEDERAL|MEXICO|07000|GFE000627QW0|GAFI FERRELECTRICO, S. A. DE C. V.|ANTIGUA CARRETERA A SAN PEDRO|1585|AVIACION|TORREON|COAHUILA|MEXICO|27050|100|T. CONDUIT 16MM E.AZ. GALV S/C|120.00|12000.00|IVA|16|864.00||"
        'SelloDigital(strCadenaOriginal)
    End Sub

    Public Function Mex_CreateSignature(ByVal strCadena As String, ByVal strDirCadena As String, ByVal strRutaKey As String, ByVal strPassword As String) As String
        '@Proc: Mex_CreateSignature
        '@Lang: VB.NET
        '@ Creates a signature (sello) value in base64 format given the piped-string input and the private key
        Dim strDataFile As String
        Dim strKeyFile As String
        'Dim strPassword As String
        Dim sbPrivateKey As New StringBuilder
        Dim abDigest() As Byte
        Dim abBlock() As Byte
        Dim nBlockLen As Integer
        ''Dim nLen As Integer
        ''Dim nRet As Integer
        Dim strBase64 As String
        Dim strCadSha1 As String
        Dim abDataUTF8 As Byte()


        ' INPUT: File containing piped-string formed from XML doc in UTF-8 format (NOTE: no Unicode markers in the file),
        '        private key file and its secret password(!)
        'strDataFile = "Muestra-v2_PipedString-UTF8.txt"
        'strKeyFile = "aaa010101aaa_CSD_01.key"
        ' Test password - CAUTION: DO NOT hardcode production passwords!
        'strPassword = "a0123456789"

        strDataFile = strDirCadena
        strKeyFile = strRutaKey


        ' 1. Form the message digest hash of the piped-string directly from the file
        ' 1. Convert to UTF-8
        ' -- In VB.NET, it is easier to convert directly to a byte arra
        strCadSha1 = Mex_CreateDigestFromString(strCadena)
        abDataUTF8 = System.Text.Encoding.UTF8.GetBytes(strCadena)
        abDigest = Hash.BytesFromBytes(abDataUTF8, HashAlgorithm.Sha1)




        'abDigest = Hash.BytesFromFile(strDataFile, HashAlgorithm.Sha1)
        If abDigest.Length <= 0 Then
            'MessageBox.Show("ERROR: Failed to create hash of file.")
            Exit Function
        End If
        ' Display in hex
        'MessageBox.Show("Digest=" & Cnv.ToHex(abDigest))

        ' 2. Sign the message digest using the private key

        ' 2.1 Read in private key from encrypted .key file
        sbPrivateKey = Rsa.ReadEncPrivateKey(strKeyFile, strPassword)
        If sbPrivateKey.Length = 0 Then
            'MessageBox.Show("ERROR: Failed to read private key")
            Exit Function
        End If
        ' -- show we got something
        'MessageBox.Show("Private key is " & Rsa.KeyBits(sbPrivateKey.ToString) & " bits long")

        ' 2.2 Encode the digest ready for signing with `Encoded Message for Signature' block using PKCS#1 v1.5 method
        nBlockLen = Rsa.KeyBytes(sbPrivateKey.ToString)
        abBlock = Rsa.EncodeDigestForSignature(nBlockLen, abDigest, HashAlgorithm.Sha1)
        If abBlock.Length = 0 Then
            ' MessageBox.Show("ERROR with Rsa.EncodeDigestForSignature")
            Exit Function
        End If
        'MessageBox.Show("INPUT BLOCK= " & Cnv.ToHex(abBlock))

        ' 2.3 Sign using the RSA private key
        abBlock = Rsa.RawPrivate(abBlock, sbPrivateKey.ToString)
        ' Display in hex
        'MessageBox.Show("OUTPUT BLOCK=" & Cnv.ToHex(abBlock))

        ' 2.4 Clean up
        Wipe.String(sbPrivateKey)

        ' 3. Convert to base64 and output result
        strBase64 = System.Convert.ToBase64String(abBlock)
        'MessageBox.Show("SIGNATURE VALUE=" & strBase64)

        Mex_CreateSignature = strBase64

    End Function

    Public Function Mex_ExtractDigestFromSignature(ByVal strcadBase64 As String, ByVal strCertificado As String) As String
        '@Proc: Mex_ExtractDigestFromSignature
        '@Lang: VB6
        '@ Extracts the message digest from a signature (sello) string using the X.509 certificate (certificado) value
        Dim sbPublicKey As StringBuilder
        Dim strSello As String
        'Dim strCertificado As String
        Dim abDigest() As Byte
        Dim abData() As Byte
        Dim nSigLen As Integer
        Dim strDigestHex As String

        Mex_ExtractDigestFromSignature = ""
        ' INPUT: Base64 strings extracted from the XML file (Ref: Muestra_v2_signed2.xml)
        'strSello = "UlUSwGNEicfigV6i4RhTy0eb2RYWFYyFatJFcM/u5Wlkb5XRxXiCizTGw5Yxz9oZNk8msAgO4C5Gevjh+S2TJPZueYhaQeZlo6k0rE3CQexkOGVRpHkvAoAgOM5kGKzYe24DKZbTgjNL+ai+tbhEHmRAFcpv2rDpehbL3w6BnYU="
        'strCertificado = "MIIDhDCCAmygAwIBAgIUMTAwMDEyMDAwMDAwMDAwMjI1MTcwDQYJKoZIhvcNAQEFBQAwgcMxGTAXBgNVBAcTEENpdWRhZCBkZSBNZXhpY28xFTATBgNVBAgTDE1leGljbywgRC5GLjELMAkGA1UEBhMCTVgxGjAYBgNVBAMTEUFDIGRlIFBydWViYXMgU0FUMTYwNAYDVQQLFC1BZG1pbmlzdHJhY2nzbiBkZSBTZWd1cmlkYWQgZGUgbGEgSW5" & _
        '    "mb3JtYWNp824xLjAsBgNVBAoUJVNlcnZpY2lvIGRlIEFkbWluaXN0cmFjafNuIFRyaWJ1dGFyaWEwHhcNMDgwODIxMTUyMjA4WhcNMTAwODIxMTUyMjA4WjCBmDElMCMGA1UELRMcQUFBMDEwMTAxQUFBIC8gQUFBQTAxMDEwMUFBQTEeMBwGA1UEBRMVIC8gQUFBQTAxMDEwMUhERlJYWDAxMRIwEAYDVQQKEwlNYXRyaXogU0ExEzARBgNVBA" & _
        '   "sTClVuaWRhZCAxMCAxEjAQBgNVBAMTCU1hdHJpeiBTQTESMBAGA1UEKRMJTWF0cml6IFNBMIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDpmiW1q9gyzCFtMcbaFDJexk2IpLoTdNXg4ToGRZ/f+hIjmj3N6ODWX1ARNFGYocEHf113GpW5Oe/mj6UqhBpiH4JRTNR4Udb8myJTArIlODynVHuIUuyhKo7gbMbDdXjilTAYY2XWQuQ7aDtWw" & _
        '  "ntUmNg4vAC/F3OtRz3+y9wM5QIDAQABox0wGzAMBgNVHRMBAf8EAjAAMAsGA1UdDwQEAwIGwDANBgkqhkiG9w0BAQUFAAOCAQEAafyD4gMsOvq7E3raPntmQlJTxpWwNySqskE7fe23HVL9UKFCUlWWx/W8gluxIX9S19y17iWnGbtmbNddHxG5PznPsy/a8PlwNHjDW0FOpia2LsvDrNcdPiJhzL/1OVagkenffFf8bLEetF3ktxZ7ifcH1yxV" & _
        ' "xpZ7PS/pe8YIOpWRuMmTV4ypGdsw9TW3HVP5IJ/canuQGPTb3LQ8ojihW2dHnC6ojaWW4GHFSZAPhQJ/DaH/UgFjaQke/RBtoAketfROdG+1qYeA1q/is04O4AXNmMByGp7ZnvGNrO9LDBvs3eKN4ZYcQyjxFEbr1X/xUqHCRF1VEkkC5jJQ1ktC4g=="

        strSello = strcadBase64
        strCertificado = strCertificado

        ' 1. Read in Public key from X.509 certificate string directly
        sbPublicKey = Rsa.GetPublicKeyFromCert(strCertificado)
        If sbPublicKey.Length = 0 Then
            'MessageBox.Show("ERROR: failed to read Certificado string")
            Exit Function
        End If
        ' --Show we got something useful
        ' MessageBox.Show("Public key is " & Rsa.KeyBits(sbPublicKey.ToString) & " bits long")

        ' 2. Convert base64 signature value to byte array
        abData = System.Convert.FromBase64String(strSello)
        nSigLen = abData.Length
        ' 2a. Check lengths match
        'MessageBox.Show("Signature bytes=" & nSigLen)
        'MessageBox.Show("Key bytes =" & Rsa.KeyBytes(sbPublicKey.ToString))
        If nSigLen <> Rsa.KeyBytes(sbPublicKey.ToString) Then
            'MessageBox.Show("ERROR: key length does not match signature")
            Exit Function
        End If

        ' 3.Decrypt using RSA public key
        abData = Rsa.RawPublic(abData, sbPublicKey.ToString)
        'MessageBox.Show("RSA_RawPublic returns " & abData.Length & " bytes (expected >0)")
        If abData.Length = 0 Then
            'MessageBox.Show("ERROR: failed to decrypt RSA signature.")
            Exit Function
        End If
        ' Display result in hex
        'MessageBox.Show("Decrypted signature=" & vbCrLf & Cnv.ToHex(abData))

        ' 4. Decode to extract the original message digest
        abDigest = Rsa.DecodeDigestForSignature(abData)
        ' 5. Convert to hex format
        strDigestHex = Cnv.ToHex(abDigest)

        ' OUTPUT: Digest in hex format
        'MessageBox.Show("Sha1 digest as hex: " & strDigestHex)
        'Mex_ExtractDigestFromSignature = strDigestHex
        Mex_ExtractDigestFromSignature = LCase(Cnv.ToHex(abDigest))

    End Function

    Public Function Mex_CreateDigestFromString(ByVal strCadena As String) As String
        '@Proc: Mex_CreateDigestFromString
        '@Lang: VB.NET
        '@ Creates the Sha1 digest of the input string after converting to UTF-8 encoding
        Dim strData As String
        Dim abDataUTF8 As Byte()
        Dim strDigest As String

        ' INPUT: Our original string data in "Latin-1" encoding
        'strData = "||2.0|A|1|2009-08-16T16:30:00|1|2009|ingreso|Una sola exhibición|350.00|5.25|397.25|ISP900909Q88|Industrias del Sur Poniente, S.A. de C.V.|Alvaro Obregón|37|3|Col. Roma Norte|México|Cuauhtémoc|Distrito Federal|México|06700|Pino Suarez|23|Centro|Monterrey|Monterrey|Nuevo Léon|México|95460|CAUR390312S87|Rosa María Calderón Uriegas|Topochico|52|Jardines del Valle|Monterrey|Monterrey|Nuevo León|México|95465|10|Caja|Vasos decorados|20.00|200|1|pieza|Charola metálica|150.00|150|IVA|15.00|52.50||"
        strData = strCadena
        'MessageBox.Show("INPUT=" & strData)

        ' 1. Convert to UTF-8
        ' -- In VB.NET, it is easier to convert directly to a byte array
        abDataUTF8 = System.Text.Encoding.UTF8.GetBytes(strData)

        ' 2. Create the message digest hash
        strDigest = Hash.HexFromBytes(abDataUTF8, HashAlgorithm.Sha1)
        'strDigest = Hash.HexFromString(strCadena, HashAlgorithm.Sha1)

        ' OUTPUT: Display digest in hex format
        'MessageBox.Show("Digest=" & strDigest)
        Mex_CreateDigestFromString = strDigest

    End Function

    Public Function Mex_CheckKeyAndCertMatch(ByVal strRutaCertificado As String, ByVal strRutaKey As String, ByVal strPassword As String) As String
        '@Proc: Mex_Create_Digest
        '@Lang: VB.NET
        '@ Checks that the keys in the private key and certificate match
        Dim strCertFile As String
        Dim strKeyFile As String
        Dim sbPassword As New StringBuilder
        Dim sbPublicKey As New StringBuilder
        Dim sbPrivateKey As New StringBuilder
        Dim nRet As Integer

        ' INPUT: filenames for certificate and private key files
        'strCertFile = "aaa010101aaa_CSD_01.cer"
        'strKeyFile = "aaa010101aaa_CSD_01.key"
        ' Test password - CAUTION: DO NOT hardcode production passwords!
        'sbPassword.Append("a0123456789")

        strCertFile = strRutaCertificado
        strKeyFile = strRutaKey
        sbPassword.Append(strPassword)

        ' 1. Read in private key from encrypted .key file
        sbPrivateKey = Rsa.ReadEncPrivateKey(strKeyFile, sbPassword.ToString)
        If sbPrivateKey.Length > 0 Then
            'MessageBox.Show("Private key is " & Rsa.KeyBits(sbPrivateKey.ToString) & " bits")
        Else
            'MessageBox.Show("ERROR: Cannot read private key file.")
            Exit Function
        End If

        ' 2. Clean up password as we are done with it
        Wipe.String(sbPassword)

        ' 3. Read in public key from certificate
        sbPublicKey = Rsa.GetPublicKeyFromCert(strCertFile)
        If sbPublicKey.Length > 0 Then
            'MessageBox.Show("Public key is " & Rsa.KeyBits(sbPublicKey.ToString) & " bits")
        Else
            ' MessageBox.Show("ERROR: Cannot read certificate file.")
            Exit Function
        End If

        ' 4. See if the two key strings match
        nRet = Rsa.KeyMatch(sbPrivateKey.ToString, sbPublicKey.ToString)
        If nRet = 0 Then
            'MessageBox.Show("OK, key strings match.")
        Else
            'MessageBox.Show("FAILED: key strings do not match.")
        End If

        ' 5. Clean up private key string
        Wipe.String(sbPrivateKey)

    End Function

    Public Function Mex_Convert_Latin1_To_UTF8(ByVal strCadena As String) As String
        '@Proc: Mex_Convert_Latin1_To_UTF8
        '@Lang: VB.NET $
        '@ Checks if a string is valid UTF-8 and converts between Latin-1 and UTF-8 encodings
        Dim strData As String
        Dim strDataUTF8 As String
        Dim nRet As Integer

        ' Our original string data is in "Latin-1" encoding
        'strData = "Asociación Mexicana de Estándares para el Comercio Electrónico A.C.|México|"
        'MessageBox.Show("INPUT:   " & strData)

        strData = strCadena
        ' Is it valid UTF-8?
        nRet = Cnv.CheckUTF8(strData)
        'MessageBox.Show("CNV.CheckUTF8 returns " & nRet & " (0 => Not valid UTF-8)")

        ' So convert to UTF-8: use the standard method in .NET
        strDataUTF8 = System.Text.Encoding.Default.GetString(System.Text.Encoding.UTF8.GetBytes(strData))
        ' Which may not display correctly ...!
        MessageBox.Show("UTF-8:   " & strDataUTF8)

        nRet = Cnv.CheckUTF8(strDataUTF8)
        'MessageBox.Show("CNV.CheckUTF8 returns " & nRet & " (1,2,3 => Valid UTF-8)")

        Mex_Convert_Latin1_To_UTF8 = strDataUTF8
    End Function

    Public Sub Mex_ValidateCert()
        '@Proc: Mex_ValidateCert
        '@Lang: VB.NET
        '@ Checks that a given X.509 certificate really was issued by the issuer and has not expired
        Dim strCert As String
        Dim strIssuerCert As String
        Dim nRet As Integer
        Dim fIsValid As Boolean

        ' INPUT: Filenames of certificate to be checked and issuer's certificate
        strCert = "aaa010101aaa_CSD_01.cer"
        strIssuerCert = "AC_SAT2048.cer"

        ' 1. Was this cert signed by the purported issuer?
        nRet = X509.VerifyCert(strCert, strIssuerCert)
        MessageBox.Show("X509_VerifyCert returns " & nRet)
        If nRet < 0 Then
            MessageBox.Show("ERROR: Validation failed")
        ElseIf nRet > 0 Then
            MessageBox.Show("ERROR: " & General.ErrorLookup(nRet))
        Else
            MessageBox.Show("OK, cert was signed by issuer.")
        End If

        ' 2. Is this cert still valid now?
        fIsValid = X509.CertIsValidNow(strCert)
        MessageBox.Show("X509_CertIsValidNow returns " & fIsValid)
        If Not fIsValid Then
            MessageBox.Show("ERROR: cert has expired")
        Else
            MessageBox.Show("OK, cert is still valid now.")
        End If

    End Sub

    Public Function Mex_CertToBase64String(ByVal strCertificado As String) As String
        '@Proc: Mex_CertToBase64String
        '@Lang: VB.NET
        '@ Converts an X.509 certificate file into a base64 string suitable for Certificado field in XML,
        '  and shows how this string form can be treated just like the .cer file.
        Dim strCertString As String
        Dim strCertFile As String
        Dim strThumb1 As String
        Dim strThumb2 As String

        'strCertFile = "aaa010101aaa_CSD_01.cer"
        strCertFile = strCertificado

        ' Read in certificate file's data to a string
        strCertString = X509.ReadStringFromFile(strCertFile)
        'MessageBox.Show("For certificate '" & strCertFile & "':")
        'MessageBox.Show(strCertString)

        ' Check that the two versions of the certificate are identical by computing their SHA-1 thumbprints
        strThumb1 = X509.CertThumb(strCertFile, HashAlgorithm.Sha1)
        strThumb2 = X509.CertThumb(strCertString, HashAlgorithm.Sha1)
        'MessageBox.Show("SHA-1(file)  =" & strThumb1)
        'MessageBox.Show("SHA-1(string)=" & strThumb2)
        If strThumb1 = strThumb2 Then
            ' MessageBox.Show("Certificates are identical")
        Else
            'MessageBox.Show("ERROR: certificates do not match")
        End If
        Mex_CertToBase64String = strCertString
    End Function

    Public Sub Mex_SAT_SerialNumber()
        '@Proc: Mex_SAT_SerialNumber
        '@Lang: VB.NET
        '@ Extracts the serial number from a SAT-issued X.509 certificate and displays in base64 format
        Dim strCertFile As String
        Dim strSerialNumber As String
        Dim strSerialSAT As String

        ' Extract the certificate's serial number
        strCertFile = "AAA010101AAAsd.cer"
        strSerialNumber = X509.CertSerialNumber(strCertFile)
        MessageBox.Show("X.509 Serial Number=0x" & strSerialNumber)
        ' Decode from hex-encoded integer to string of ASCII digits
        strSerialSAT = System.Text.Encoding.Default.GetString(Cnv.FromHex(strSerialNumber))
        MessageBox.Show("Decoded SAT Format ='" & strSerialSAT & "'")
    End Sub

    Public Sub Mex_QueryCertString()
        '@Proc: Mex_QueryCertString
        '@Lang: VB.NET
        '@ Extracts various details from a certificate string
        Dim strCertificado As String
        Dim strOutput As String
        Dim strQuery As String

        ' INPUT: Certificado string frm XML file. This is the same as in the file aaa010101aaa_CSD_01.cer.
        strCertificado = "MIIDhDCCAmygAwIBAgIUMTAwMDEyMDAwMDAwMDAwMjI1MTcwDQYJKoZIhvcNAQEFBQAwgcMxGTAXBgNVBAcTEENpdWRhZCBkZSBNZXhpY28xFTATBgNVBAgTDE1leGljbywgRC5GLjELMAkGA1UEBhMCTVgxGjAYBgNVBAMTEUFDIGRlIFBydWViYXMgU0FUMTYwNAYDVQQLFC1BZG1pbmlzdHJhY2nzbiBkZSBTZWd1cmlkYWQgZGUgbGEgSW5" & _
            "mb3JtYWNp824xLjAsBgNVBAoUJVNlcnZpY2lvIGRlIEFkbWluaXN0cmFjafNuIFRyaWJ1dGFyaWEwHhcNMDgwODIxMTUyMjA4WhcNMTAwODIxMTUyMjA4WjCBmDElMCMGA1UELRMcQUFBMDEwMTAxQUFBIC8gQUFBQTAxMDEwMUFBQTEeMBwGA1UEBRMVIC8gQUFBQTAxMDEwMUhERlJYWDAxMRIwEAYDVQQKEwlNYXRyaXogU0ExEzARBgNVBA" & _
            "sTClVuaWRhZCAxMCAxEjAQBgNVBAMTCU1hdHJpeiBTQTESMBAGA1UEKRMJTWF0cml6IFNBMIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDpmiW1q9gyzCFtMcbaFDJexk2IpLoTdNXg4ToGRZ/f+hIjmj3N6ODWX1ARNFGYocEHf113GpW5Oe/mj6UqhBpiH4JRTNR4Udb8myJTArIlODynVHuIUuyhKo7gbMbDdXjilTAYY2XWQuQ7aDtWw" & _
            "ntUmNg4vAC/F3OtRz3+y9wM5QIDAQABox0wGzAMBgNVHRMBAf8EAjAAMAsGA1UdDwQEAwIGwDANBgkqhkiG9w0BAQUFAAOCAQEAafyD4gMsOvq7E3raPntmQlJTxpWwNySqskE7fe23HVL9UKFCUlWWx/W8gluxIX9S19y17iWnGbtmbNddHxG5PznPsy/a8PlwNHjDW0FOpia2LsvDrNcdPiJhzL/1OVagkenffFf8bLEetF3ktxZ7ifcH1yxV" & _
            "xpZ7PS/pe8YIOpWRuMmTV4ypGdsw9TW3HVP5IJ/canuQGPTb3LQ8ojihW2dHnC6ojaWW4GHFSZAPhQJ/DaH/UgFjaQke/RBtoAketfROdG+1qYeA1q/is04O4AXNmMByGp7ZnvGNrO9LDBvs3eKN4ZYcQyjxFEbr1X/xUqHCRF1VEkkC5jJQ1ktC4g=="

        ' 1. Get the Issuer's distinguished name
        strOutput = X509.CertIssuerName(strCertificado, ";")
        MessageBox.Show("ISSUER= [" & strOutput & "]")

        ' 2. Get the Subject's distinguished name
        strOutput = X509.CertSubjectName(strCertificado, ";")
        MessageBox.Show("SUBJECT=[" & strOutput & "]")

        ' 3. Get the Serial Number
        strOutput = X509.CertSerialNumber(strCertificado)
        MessageBox.Show("X.509 Serial Number=0x" & strOutput)

        ' 4. Get the expiry date
        strOutput = X509.CertExpiresOn(strCertificado)
        MessageBox.Show("Expires on: " & strOutput)

        ' 5. Get the signature algorithm
        strQuery = "signatureAlgorithm"
        strOutput = X509.QueryCert(strCertificado, strQuery)
        MessageBox.Show(strQuery & "=" & strOutput)

    End Sub


    Public Function SelloDigital(ByVal strCadena As String, ByVal rutaCer As String, ByVal rutaKey As String, ByVal psw As String)
        Dim strDirCadena As String = Application.StartupPath + "\CadenaOriginal.txt"
        'Dim strDirCadena As String = "C:\Facturacion\CadenaOriginal.txt"
        Dim strRutaCertificado As String
        Dim strRutaKey As String
        Dim strCertificado As String
        Dim strValidaCertif As String
        Dim strPassword As String
        Dim strValidaSello As String
        Dim strcadSha1 As String
        ' Dim sw As New StreamWriter(strDirCadena)

        'estas rutas y password se debe pasar por parametro de la tabla configuracion
        'strDirCadena = "C:\Facturacion\CadenaOriginal.txt"
        strRutaCertificado = rutaCer '"C:\Facturacion\aaa010101aaa_csd_02.cer"
        strRutaKey = rutaKey '"C:\Facturacion\aaa010101aaa_csd_02.key"
        strPassword = psw '"a0123456789"
        strCertificado = Mex_CertToBase64String(strRutaCertificado)
        ''Verifica Certificado

        strValidaCertif = Mex_CheckKeyAndCertMatch(strRutaCertificado, strRutaKey, strPassword)
        If strValidaCertif = "Error en .cer" Or strValidaCertif = "Error en .key" Or strValidaCertif = "Error en Llaves" Then
            'MsgBox("Error al generar el Documento Electrónico; Verifique el Certificado")
            Exit Function
        End If

        ''''Obtiene Sha1
        strcadSha1 = Mex_CreateDigestFromString(strCadena)

        ''Crea Sello Digital
        'strCadena = Mex_Convert_Latin1_To_UTF8(strCadena)
        'sw.WriteLine(strCadena)
        'sw.Flush()
        'sw.Close()
        ''Genera el Sello Digital
        strcadBase64 = Mex_CreateSignature(strCadena, "C:\CadenaOriginal.txt", strRutaKey, strPassword)
        ''Verifica Sello Digital
        strValidaSello = Mex_ExtractDigestFromSignature(strcadBase64, strCertificado)
        If strValidaSello <> strcadSha1 Then
            MessageBox.Show("Error al generar el Sello Digital")
            Exit Function
        End If
    End Function

End Class