using UnityEngine;

public static class ValidateUtilities
{
    public static void NullCheckVariable<T>(Object objectToCheck, string fieldName, T fieldValue, bool isError)
    {
        if (fieldValue != null)
            return;

        if (isError)
        {
            Debug.LogError($"{objectToCheck.name} don't have value in {fieldName}");
        }
        else
        {
            Debug.Log($"{objectToCheck.name} don't have value in {fieldName}");
        }
    }
}
