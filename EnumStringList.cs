using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace YourMouseMaster
{
    public class EnumStringItem
    {
        public object Enumeration;
        public String Name;

        // constructor
        public EnumStringItem()
        {

        }
    }


    public class EnumStringList
    {
        public Collection<EnumStringItem> EnumStringColl;
        
        // constructor
        public EnumStringList()
        {
            EnumStringColl = new Collection<EnumStringItem>();
        }

        public bool Add(EnumStringItem Item)
        {
            // name has to be unique
            EnumStringItem FoundItem = new EnumStringItem();
            if (FindByName(Item.Name, ref FoundItem) == true) return false;          
            EnumStringColl.Add(Item);
            return true;
        }

        public bool FindByName(String name, ref EnumStringItem FoundItem)
        {
            foreach (EnumStringItem single in EnumStringColl)
            {
                if (single.Name == name)
                {
                    // name found

                    FoundItem = single;
                    return true;
                }
            }
            // nothing found
            return false;
        }

     
    }
}
