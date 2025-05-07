using UnityEngine;

public class MergeManager : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public AudioSource audioSource;
    public AudioClip mergeSound;
    public GameObject mergeEffect; // Optional VFX prefab

    public void MergeIngredients(Ingredient ingredient1, Ingredient ingredient2)
    {
        if (ingredient1 != null && ingredient2 != null)
        {
            if (ingredient1.displayName == ingredient2.displayName)
            {
                // Optional visual/sound effect
                if (mergeEffect != null)
                    Instantiate(mergeEffect, ingredient1.transform.position, Quaternion.identity);

                if (mergeSound != null && audioSource != null)
                    audioSource.PlayOneShot(mergeSound);

                // Combine quantities (if you care about it)
                ingredient1.quantity += ingredient2.quantity;

                // Create merged version based on ingredient1
                Ingredient mergedIngredient = CreateMergedIngredient(ingredient1);

                // Remove originals
                Destroy(ingredient1.gameObject);
                Destroy(ingredient2.gameObject);

                // Send to inventory
                SpawnMergedIngredient(mergedIngredient);
            }
            else
            {
                Debug.Log("Ingredients do not match.");
            }
        }
    }

    Ingredient CreateMergedIngredient(Ingredient baseIngredient)
    {
        GameObject mergedObj = Instantiate(baseIngredient.gameObject);
        Ingredient merged = mergedObj.GetComponent<Ingredient>();

        // Clean up the name to avoid endless "_merged_merged"
        string baseName = baseIngredient.displayName.Replace("_merged", "");
        merged.displayName = baseName + "_merged";
        merged.quantity = 1;

        return merged;
    }

    void SpawnMergedIngredient(Ingredient mergedIngredient)
    {
        if (inventoryManager != null)
        {
            inventoryManager.AddToInventory(mergedIngredient);
        }
        else
        {
            Debug.LogWarning("InventoryManager is not assigned.");
        }
    }
}