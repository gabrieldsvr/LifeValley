# COMO CRIAR NOVOS ITENS DE PLANTAÇÃO
*-*------------------------------------------------------------------------------------------------------

<h2>
Criar o Item do Dropavel
</h2>
 
 - Criar o _itemData_ colocando nome e icone
 - Dentro de prefabs/crops/ItemCarry criar um prefab do item dropavel.
   - O item deve ter box collider2d, script Collectable, Item script e Sprite Renderer.

<h3>
Colocar o item prefab dentro da lista de itens colletaveis dentro do itensManager dentro do gameManager
<h3/>

<h2>
Criar o pack de sementes
</h2>


- Criar o _itemData_ colocando nome e icone
  - O nome deve começar com Seed.... ex: "SeedTomato"
- Criar o _cropData_ colocando os dados sobre a colheita do item
- Criar o _seedData_ colocando nome da semente e o cropData criado
- Dentro de prefabs/crops/seeds pack criar um prefab do pack de semente.
   - O pack deve ter box collider2d, script Collectable,Seed script, Item script e Sprite Renderer.

<h3>
Colocar o pack prefab dentro da lista de itens colletaveis dentro do itensManager e seedManager dentro do gameManager
</h3>
