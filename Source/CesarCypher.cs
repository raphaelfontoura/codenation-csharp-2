using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Codenation.Challenge
{
    public class CesarCypher : ICrypt, IDecrypt
    {
        public string Crypt(string message)
        {
            TestMessage(message);
            
            return ReturnMessage(message.ToLower(), 3);
        }

        public string Decrypt(string cryptedMessage)
        {
            TestMessage(cryptedMessage);
            return ReturnMessage(cryptedMessage.ToLower(), -3);
        }

        public void TestMessage(string message)
        {
            if (message == null) throw new ArgumentNullException();

            var rxAlphanum = new Regex(@"^[a-zA-Z0-9 ]*$");
            if (!rxAlphanum.IsMatch(message)) throw new ArgumentOutOfRangeException();
        }

        public string ReturnMessage(string message, int key)
        {
            var sb = new StringBuilder();
            var rx = new Regex(@"[a-z]");

            foreach (char chr in message)
            {
                if (!rx.IsMatch(chr.ToString()))
                {
                    sb.Append(chr);
                    continue;
                }
                
                int codeChar = chr - 97 + key;
                int newChar = Mod(codeChar,26) + 97;
                // int newChar = (((codeChar - 97 + key) % 26) + 97);
                // o cálculo de módulo do Csharp não retorna correto para números negativos.
                // criado função Mod de acordo com https://github.com/dotnet/csharplang/issues/1408
                sb.Append((char)newChar);

            }
            return sb.ToString();
        }

        public static int Mod(int a, int b)
        {
            int c = a % b;
            if ((c < 0 && b > 0) || (c > 0 && b < 0))
            {
                c += b;
            }
            return c;
        }
    }
}
