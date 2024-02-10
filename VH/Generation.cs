using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VH
{
    public class Generation
    {
        public static byte[] GenerateKey()
        {
            using (var randomNumberGenerator = RandomNumberGenerator.Create())
            {
                var key = new byte[32];//256-bit
                randomNumberGenerator.GetBytes(key);
                return key;
            }
        }
        
        public static string GenerateMove(string[] moves)
        {
            Random random = new Random();
            return moves[random.Next(moves.Length)];
        }

        public static string CalCulateHMAC(byte[] key, string move)
        {
            using (HMACSHA256 hmac = new HMACSHA256(key))
            {
                byte[] moveBytes = Encoding.UTF8.GetBytes(move);
                byte[] hmacBytes = hmac.ComputeHash(moveBytes);

                return BitConverter.ToString(hmacBytes).Replace("-", "");
            }
        }
    }
}
