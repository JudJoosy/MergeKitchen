using UnityEngine;

public class MergeManager : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public AudioSource audioSource;
    public AudioClip mergeSound;

    public void MergeIngredients(Ingredient ingredient1, Ingredient ingredient2)
    {
        if (ingredient1 != null && ingredient2 != null)
        {
            if (ingredient1.displayName == ingredient2.displayName)
            {
                ingredient1.quantity += ingredient2.quantity;
                Destroy(ingredient2.gameObject);

                Ingredient mergedIngredient = CreateMergedIngredient(ingredient1);
                SpawnMergedIngredient(mergedIngredient);

                if (mergeSound != null && audioSource != null)
                    audioSource.PlayOneShot(mergeSound);
            }
            else
            {
                Debug.Log("Ingredients do not match.");
            }
        }
    }

    Ingredient CreateMergedIngredient(Ingredient ingredient)
    {
        GameObject mergedObj = Instantiate(ingredient.gameObject);
        Ingredient merged = mergedObj.GetComponent<Ingredient>();

        // Clean up displayName to avoid merged_merged_merged
        merged.displayName = ingredient.displayName.Replace("_merged", "") + "_merged";
        merged.quantity = 1;

        return merged;
    }

    void SpawnMergedIngredient(Ingredient mergedIngredient)
    {
        inventoryManager.AddToInventory(mergedIngredient);
    }
}