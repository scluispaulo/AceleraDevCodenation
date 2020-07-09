using System;

namespace Codenation.Challenge 
{
    public class CesarCypher : ICrypt, IDecrypt 
    {
        public string Crypt(string message) 
        {
            string result = "";
            int shift = 3;
            bool LettlerIsLower;
            try 
            {
                if (message == null) 
                {
                    throw new ArgumentNullException();
                }
                message = message.ToLower();
                for (int i=0; i<message.Length; i++) 
                {
                    LettlerIsLower = ((int)(message[i])>96 && (int)(message[i])<123);
                    if (!(( LettlerIsLower || char.IsDigit(message[i]) || char.IsSeparator(message[i]))))
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    if (char.IsLower(message[i]))
                    {
                        // encontra valor int do char, soma shift, encontra char do int, 97 inicio alfabeto minúsculo.
                        result = result.Insert(i, char.ToString((char)(((int)message[i] + shift - 97) % 26 + 97)));
                    } 
                    else
                    { 
                        result = result.Insert(i, char.ToString(message[i]));
                    } 
                } 
                return result; 
            }
            catch (ArgumentNullException e) 
            {
                throw e;
            }
            catch (ArgumentOutOfRangeException e) 
            {
                throw e;
            }
        }

            public string Decrypt(string cryptedMessage) 
            {
                string result = "";
                int shift = 26 - 3; // DeCrypt = ICrypt (26 - shift);
                bool LettlerIsLower;
                try 
                {
                    if (cryptedMessage == null) 
                    {
                        throw new ArgumentNullException();
                    }
                    cryptedMessage = cryptedMessage.ToLower();
                    for (int i=0; i<cryptedMessage.Length; i++) 
                    {
                        LettlerIsLower = ( (int)(cryptedMessage[i])>96 && (int)(cryptedMessage[i])<123 );
                        if (!( LettlerIsLower || char.IsDigit(cryptedMessage[i]) || char.IsSeparator(cryptedMessage[i]))) 
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                        if (char.IsLower(cryptedMessage[i]))
                        {
                            // encontra valor int do char, soma shift, encontra char do int, 97 inicio alfabeto minúsculo.
                            result = result.Insert(i, char.ToString((char)(((int)cryptedMessage[i] + shift - 97) % 26 + 97)));
                        } 
                        else 
                        { 
                            result = result.Insert(i, char.ToString(cryptedMessage[i]));
                        } 
                    } 
                    return result; 
                }
                catch (ArgumentNullException e) 
                {
                    throw e;
                }
                catch (ArgumentOutOfRangeException e) 
                {
                    throw e;
                }
            }
    }
}
