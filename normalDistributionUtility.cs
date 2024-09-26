using UnityEngine;

public class normalDistributionUtility : MonoBehaviour
{
    // Generates a normally distributed random number with mean 0 and standard deviation 1
    public static float GenerateStandardNormal()
    {
        float u1 = 1.0f - Random.Range(0.0f, 1.0f); // Uniform(0,1] random doubles
        float u2 = 1.0f - Random.Range(0.0f, 1.0f);
        float randStdNormal = Mathf.Sqrt(-2.0f * Mathf.Log(u1)) * Mathf.Sin(2.0f * Mathf.PI * u2); // Random normal(0,1)
        return randStdNormal;
    }

    // Generates a normally distributed random number with specified mean and standard deviation
    public static float GenerateNormal(float mean, float stdDev)
    {
        return mean + stdDev * GenerateStandardNormal();
    }

    // Generates a normally distributed random number within a specified range
    public static float GenerateNormalInRange(float min, float max, float mean, float stdDev)
    {
        float result;
        do
        {
            result = GenerateNormal(mean, stdDev);
        } while (result < min || result > max);
        return result;
    }
}
