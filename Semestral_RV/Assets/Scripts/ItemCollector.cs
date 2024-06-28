using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public string itemName = "Item X";

    public void Collect()
    {
        // Aqui você pode adicionar qualquer lógica adicional ao coletar o item, como adicioná-lo ao inventário do jogador.
        gameObject.SetActive(false);
    }
}
