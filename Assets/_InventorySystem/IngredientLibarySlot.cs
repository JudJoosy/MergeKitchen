using UnityEngine;

public static class IngredientLibrary
{
    public static Sprite GetSpriteByName(string name)
    {
        return Resources.Load<Sprite>("Ingredients/" + name);
    }
}
