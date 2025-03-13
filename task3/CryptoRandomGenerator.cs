using System.Security.Cryptography;

namespace task3
{
    internal class CryptoRandomGenerator
    {
        public int num { get; private set; }
        public byte[] key { get; private set; } = Array.Empty<byte>();

        public CryptoRandomGenerator(int min, int max)
        {
            GenerateRandomKey();
            GenerateRandomNumber(min, max);
        }

        public byte[] CalculateHMAC()
        {
            byte[] numberBytes = BitConverter.GetBytes(num);

            using var hmac = new HMACSHA3_256(key);
            return hmac.ComputeHash(numberBytes);
        }

        private void GenerateRandomKey(int keyLength = 32)
        {
            key = new byte[keyLength];
            RandomNumberGenerator.Fill(key);
        }

        private void GenerateRandomNumber(int min, int max)
        {
            num = RandomNumberGenerator.GetInt32(min, max);
        }
    }
}