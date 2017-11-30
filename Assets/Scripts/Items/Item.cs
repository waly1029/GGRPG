using UnityEngine;

//ScriptableObject はスクリプトインスタンスから独立した大量の共有データを格納できるクラスです。
/*オブジェクトに付加する必要のないゲームオブジェクトを作成する場合に、このクラスが使われます。

データストアとしての意味を持つアセットに対して有効なクラスです。

プロジェクトのアセットにバインドされている ScriptableObject のインスタンスを作成しやすくするために CreateAssetMenuAttribute を参照してください。*/
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {

    new public string name = "New Item";

    public Sprite icon = null;

    public bool isDefaultItem = false;

    public virtual void Use( ) {

        //アイテムを使用もしくは他のfuncion
        Debug.Log( "Using" + name );
    }

}
