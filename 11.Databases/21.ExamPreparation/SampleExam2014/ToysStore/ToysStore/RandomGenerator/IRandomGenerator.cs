using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGenerator
{
    public interface IRandomGenerator
    {
        int GenerateRandomNumber(int min, int max);

        string GenerateRandomString(int length);

        string GenerateRandomStringWithRandomLength(int minLength, int maxLength);

        bool IsInFavour(int percent);

        double GenerateRandomDouble(double min, double max);

        IEnumerable<string> GenerateUniqueStringsWithRandomLength(int min, int max, int count);

        IEnumerable<string> GenerateUniqueStrings(int length, int count);
    }
}
