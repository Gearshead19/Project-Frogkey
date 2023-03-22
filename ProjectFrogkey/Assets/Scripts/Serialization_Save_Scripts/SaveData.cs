using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
[System.Serializable]
public class SaveData
{
    
    private static SaveData _current;

    public int health = 5;
    public static SaveData current
    {
        get
        {
            if (_current == null)
            {
                _current = new SaveData();
            }
            return _current;
        }
    }

   // public PlayerProfile profile;

    //Put all of this in the game manager
}

