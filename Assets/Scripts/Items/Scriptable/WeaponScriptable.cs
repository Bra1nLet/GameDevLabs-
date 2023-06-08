using Items.Data;
using Items.Storage;
using UnityEngine;

namespace Items.Scriptable
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "ItemsSystem/Weapon")]
    public class WeaponScriptable : BaseItemScriptable
    {
        [SerializeField] private WeaponDescriptor _weaponDescriptor;
        
        public override ItemDescriptor ItemDescriptor => _weaponDescriptor;
    }
}