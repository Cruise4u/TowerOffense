using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Mathematics
{
    public static int GetRandomValue(int max)
    {
        var random = UnityEngine.Random.Range(0, max);
        return random;
    }

}
