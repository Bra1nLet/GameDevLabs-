using System;
using System.Collections.Generic;
using Items.Core;
using Items.Enum;

namespace Items
{
    public class EquipmentConditionChecker
    {
        public bool IsEquipmentConditionFits(Equipment equipment, List<Equipment> currentEquipment)
        {
            return true;
        }
        
        public bool TryReplaceEquipment(Equipment equipment, List<Equipment> currentEquipment, out Equipment oldEquipment)
        {
            oldEquipment = currentEquipment.Find(slot => slot.EquipmentType == equipment.EquipmentType);
            if (oldEquipment != null)
                return true;

            switch (equipment.EquipmentType)
            {
                case EquipmentType.BothHands:
                {
                    var rightHand = currentEquipment.Find(slot => slot.EquipmentType == EquipmentType.LeftHand);
                    var leftHand = currentEquipment.Find(slot => slot.EquipmentType == EquipmentType.RightHand);
                    if (rightHand != null && leftHand != null)
                        return false;

                    oldEquipment = rightHand ?? leftHand;
                    return true;
                }
                case EquipmentType.LeftHand:
                case EquipmentType.RightHand:
                    oldEquipment = currentEquipment.Find(slot => slot.EquipmentType == EquipmentType.BothHands);
                    return true;
                case EquipmentType.Helmet:
                case EquipmentType.Armor:
                case EquipmentType.Belt:
                case EquipmentType.Gloves:
                case EquipmentType.Boots:
                    return true;
                case EquipmentType.None:
                default:
                    throw new NullReferenceException($"Equipment type of item {equipment.Descriptor.ItemId} is not available for equipping");
            }
        }
    }
}